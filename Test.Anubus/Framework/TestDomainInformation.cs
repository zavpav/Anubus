using System.Linq.Expressions;
using System.Reflection;

namespace TestConsoleTest.Framework;

/// <summary> Описание домена </summary>
public interface ITestDomainInformation
{
}

public class TestDomainInformation : ITestDomainInformation
{
    public class TestDomainInfo
    {
        public TestDomainInfo(string rusName, Type domainType)
        {
            this.RusName = rusName;
            this.Domain = domainType;
        }

        /// <summary> Русское наименование домена </summary>
        public string RusName { get; }

        /// <summary> Доменных тип </summary>
        public Type Domain { get; }

        /// <summary> Url списка </summary>
        public string? ClientListUrl { get; set; }
    }

    /// <summary> Вспомогательный класс описания информации поля </summary>
    public class DomainPropertyInfo
    {
        /// <summary> Русское наименование поля, если есть TestFieldDescriptionAttribute и т.д.</summary>
        /// <remarks> Если поле не имеет "описания", то пишется "@PropertyName"</remarks>
        public string Name { get; internal set; }

        /// <summary> Реальный PropertyInfo </summary>
        public PropertyInfo PropertyInfo { get; internal set; }

        /// <summary> Getter данных </summary>
        public Func<object, object> Getter { get; internal set; }

        /// <summary> Сеттер данных по строковому значению </summary>
        /// <remarks> Если свойство только для чтения, сюда запихивается stub с логированием</remarks>
        public Action<object, string> Setter { get; internal set; }
    }

    /// <summary> Логгер </summary>
    public ILogger Logger { get { return Log.Default; } }

    protected Dictionary<string, TestDomainInfo> _domainInformations = new Dictionary<string, TestDomainInfo>();

    /// <summary> Получить информацию о домене по имени </summary>
    /// <param name="rusName">Русское имя</param>
    /// <returns>Информация по домену</returns>
    /// <exception cref="IgnoreException">Стоп тестов</exception>
    public TestDomainInfo GetDomainInfo(string rusName)
    {
        if (_domainInformations.Count == 0)
            this.FillDomainInformation();
        try
        {
            return _domainInformations[rusName];
        }
        catch (KeyNotFoundException)
        {
            throw new IgnoreException("Плохая конфигурация приложения.\nНе найдена информация для '" + rusName + "'");
        }
    }

    public List<DomainPropertyInfo> GetAllProperties(string rusName)
    {
        var allProperties = new List<DomainPropertyInfo>();

        var createGetter = new Func<Type, PropertyInfo, Func<object, object>>((tClass, tProp) =>
        {
            var untypeInstance = Expression.Parameter(typeof(object), "i"); // К нам приходит нетипизированный объект
            var typedInstance = Expression.TypeAs(untypeInstance, tClass);  // Кастим его к домену
            var cast = Expression.TypeAs(Expression.Property(typedInstance, tProp.Name), typeof(object));// Получаем значение и кастим к object всегда.
            var untyped = Expression.Lambda(cast, untypeInstance).Compile();
            return (Func<object, object>)untyped;
        }
            );

        var createSetter = new Func<Type, PropertyInfo, Action<object, object>>((tClass, tProp) =>
        {
            var untypeInstance = Expression.Parameter(typeof(object), "i"); // К нам приходит нетипизированный объект
            var typedInstance = Expression.TypeAs(untypeInstance, tClass);  // Кастим его к домену
            var untypedValue = Expression.Parameter(typeof(object), "v");  // Нетипизированное значение свойства
            var typedValue = tProp.PropertyType.IsValueType
                    ? Expression.Convert(untypedValue, tProp.PropertyType)
                    : Expression.TypeAs(untypedValue, tProp.PropertyType); // Кастим к типу значения
            var propName = Expression.Property(typedInstance, tProp.Name);  // Смотрим какой свойство хотим инициализировать
            var typedSetter = Expression.Assign(propName, typedValue);      // Типизированная инициализация
            var action = Expression.Lambda<Action<object, object>>(typedSetter, untypeInstance, untypedValue); // Обёртка action по нетипизированным значениям
            return action.Compile();
        });

        var domainType = this.GetDomainInfo(rusName).Domain;
        foreach (var pi in domainType.GetPropertiesInfo())
        {
            var domainPropertyInfo = new DomainPropertyInfo
            {
                PropertyInfo = pi
            };

            if (!pi.CanRead)
            {
                this.Logger.Fatal("Свойство {PiName} у доменного объекта {DomenType} не может быть прочитано.", pi.Name, domainType.FullName);
                throw new NotSupportedException("Свойство " + domainType.FullName + "@" + pi.Name + "не может быть прочитано. Я так не играю.");
            }
            var getter = createGetter(domainType, pi);
            domainPropertyInfo.Getter = o => getter(o);

            if (pi.CanWrite)
            {
                var setter = createSetter(domainType, pi);
                domainPropertyInfo.Setter = (o, s) =>
                {
                    var val = TestValueExtension.ParseStringValue(domainPropertyInfo.PropertyInfo.PropertyType, s);
                    setter(o, val);
                };

            }
            else
                domainPropertyInfo.Setter = (o, s) => { this.Logger.Fatal("Попытка записать свойство без сеттера {ТипОбъекта} {ИмяСвойства}", domainType.FullName, domainPropertyInfo.PropertyInfo.Name); };

            var descrAttr = pi.GetCustomAttributes(typeof(TestFieldDescriptionAttribute), true);
            if (descrAttr.Length > 1)
                throw new NotSupportedException("Нашли слишком много описаний поля " + pi.Name + " у объекта " + domainType.FullName);
            if (descrAttr.Length == 1)
                domainPropertyInfo.Name = ((TestFieldDescriptionAttribute)descrAttr[0]).RusFieldName;
            else
            {
                var defRusName = this.InternalRecodePropertyName2RusName(domainType, pi.Name);
                if (defRusName != null)
                    domainPropertyInfo.Name = defRusName;
                else
                    domainPropertyInfo.Name = "@" + pi.Name;
            }
            allProperties.Add(domainPropertyInfo);
        }
        return allProperties;
    }

    #region Декодирование русского имя свойства
    ///<summary>Декодируем русское имя свойства для объекта</summary>
    /// <remarks>
    /// Если имя начинается на "@" то считается, что мы передали системное имя объекта (нужное нам)
    /// Потом пытаемся перекодировать имя свойства по атрибуту свойства.
    /// Если не получилось - исследуем дефолтовые значения для проекта.
    /// </remarks>
    /// <exception cref="TestNotFoundException">Не найдено свойство </exception>
    public string RecodeRusName(Type domainType, string rusPropertyName)
    {
        var piName = this.InternalRecodeRusName(domainType, rusPropertyName)
                        ?? this.InternalRecodeRusNameSpecificProject(domainType, rusPropertyName);
        if (piName != null)
            return piName;

        throw new TestException(string.Format("Не получилось декодировать свойство {0} для объекта {1} ", rusPropertyName, domainType.FullName));
    }

    private static readonly Dictionary<string, string> _recodeRusName = new Dictionary<string, string>
        {
            {"Код", "Code"},
            {"Полное наименование", "FullName"},
            {"Краткое наименование", "ShortName"},
            {"Начало", "OnDate"},
            {"Конец", "ToDate"},
            {"Резерв", "IsRezerv"},
            {"Родитель", "Tsid" },
            {"Округ", "Okrug" },
        };

    ///<summary>Декодируем русское имя свойства для объекта "по умолчанию для проекта"</summary>
    /// <remarks>Зеркальная операция InternalRecodePropertyName2RusName </remarks>
    private string? InternalRecodeRusNameSpecificProject(Type domainType, string rusPropertyName)
    {
        string recodeName;
        if (_recodeRusName.TryGetValue(rusPropertyName, out recodeName))
            return recodeName;

        return null;
    }

    ///<summary>Декодируем русское имя свойства для объекта "по умолчанию для проекта"</summary>
    /// <remarks>Зеркальная операция InternalRecodeRusNameSpecificProject </remarks>
    private string? InternalRecodePropertyName2RusName(Type domainType, string propertyName)
    {
        if (_recodeRusName.All(x => x.Value != propertyName))
            return null;

        return _recodeRusName.Single(x => x.Value == propertyName).Key;
    }

    ///<summary>Декодируем русское имя свойства для объекта "по умолчанию"</summary>
    /// <remarks>
    /// Если имя начинается на "@" то считается, что мы передали системное имя объекта (нужное нам)
    /// Потом пытаемся перекодировать имя свойства по атрибуту свойства.
    /// </remarks>
    private string? InternalRecodeRusName(Type domainType, string rusPropertyName)
    {
        if (rusPropertyName.StartsWith("@"))
            return rusPropertyName.Replace("@", "");

        var piName = domainType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .Select(x => new { x, Attr = x.GetCustomAttributes(typeof(TestFieldDescriptionAttribute), true).SingleOrDefault() as TestFieldDescriptionAttribute })
                    .SingleOrDefault(x => x.Attr != null && x.Attr.RusFieldName.ToLower() == rusPropertyName.ToLower());
        if (piName != null)
            return piName.x.Name;

        return null;
    }
    #endregion

    protected void FillDomainInformation()
    {
        this._domainInformations = new Dictionary<string, TestDomainInfo>
        {
            {"ГРБС", new TestDomainInfo("ГРБС", typeof(Anubus.Api.Domain.Spr.SprGrbs)) },
            {"РзПрз", new TestDomainInfo("РзПрз", typeof(Anubus.Api.Domain.Spr.SprRzPrz)) },

        };
    }
}
