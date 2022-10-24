using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Anubus.Api.Controllers;

public static class DataWithMetaHelper
{
    /// <summary> Дополнить объект с данными метаданными (имена в camel case, т.е. первая буква в lowercase) </summary>
    /// <typeparam name="T">Тип объекта (DTO)</typeparam>
    /// <param name="entity">Сущность</param>
    /// <returns>Сущность с информацией</returns>
    public static async Task<DataWithMeta<T>> ReturnWithMeta<T>(T? entity)
        where T : class
    {
        var res = new DataWithMeta<T>(entity);
        var metaMain = await GetMetainformationForType<T>();
        res.Meta.Add(GenerateKey<T>(), metaMain);

        return res;
    }

    /// <summary> Дополнить объект с данными метаданными (имена в camel case, т.е. первая буква в lowercase) </summary>
    /// <typeparam name="T">Тип объекта (DTO)</typeparam>
    /// <typeparam name="U">Тип строк объекта (DTO)</typeparam>
    /// <param name="entity">Сущность</param>
    /// <param name="childs">Функция получения дочерних элементов</param>
    /// <returns>Сущность с информацией</returns>
    public static async Task<DataWithMeta<T>> ReturnWithMeta<T, U>(T? entity, Func<T, IEnumerable<U>> childs)
        where T : class
        where U : class
    {
        //(функции дублируются для количества дочерних элементов)

        var res = new DataWithMeta<T>(entity);
        var metaMain = await GetMetainformationForType<T>();
        res.Meta.Add(GenerateKey<T>(), metaMain);

        var childMain = await GetMetainformationForType<U>();
        res.Meta.Add(GenerateKey<U>(), childMain);

        return res;
    }

    /// <summary> Считать мета-информацию по полям с прямого типа </summary>
    /// <typeparam name="T">Тип данных</typeparam>
    public static Task<List<MetaInformation>> GetMetainformationForType<T>()
    {
        var res = new List<MetaInformation>();

        foreach (var pi in typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
        {
            var name = pi.Name.ToLowerFirst();

            var meta = new MetaInformation(name);

            if (pi.PropertyType == typeof(DateTime) || pi.PropertyType == typeof(DateTime?))
                meta.Type = "date";
            else if (pi.PropertyType == typeof(string))
                meta.Type = "string";
            else if (pi.PropertyType == typeof(int) || pi.PropertyType == typeof(long) || pi.PropertyType == typeof(int?) || pi.PropertyType == typeof(long?))
                meta.Type = "int";
            else if (pi.PropertyType == typeof(double) || pi.PropertyType == typeof(double?))
                meta.Type = "double";


            var nullabilityContext = new NullabilityInfoContext();
            var nullabilityInfo = nullabilityContext.Create(pi);
            if (nullabilityInfo.WriteState == NullabilityState.NotNull)
            {
                meta.IsRequire = true;
            }

            foreach (var att in pi.GetCustomAttributes(true))
            {
                if (att is DescriptionAttribute desc)
                    meta.Caption = desc.Description;
                else if (att is RequiredAttribute req)
                    meta.IsRequire = true;
                else if (att is MaxLengthAttribute ml)
                    meta.MaxLen = ml.Length;
                else if (att is ReadOnlyAttribute ro)
                    meta.IsReadOnly = ro.IsReadOnly;
            }
            res.Add(meta);
        }
        return Task.FromResult(res);
    }

    /// <summary> Дополнить метаданные DTO из домена. Данные ДОБАВЛЯЮТСЯ. </summary>
    /// <typeparam name="TDto">Тип DTO</typeparam>
    /// <typeparam name="TDomain">Тип домена</typeparam>
    /// <param name="resultWithMetadata">Заполненная информация</param>
    /// <param name="copyMetaType">"Конфигурация" копирования</param>
    public static async Task UpdateMetaFrom<TDto, TDomain>(this DataWithMeta<TDto> resultWithMetadata, EnumCopyMetaType copyMetaType = EnumCopyMetaType.Default)
    {
        var dtoInfo = resultWithMetadata.Meta[GenerateKey<TDto>()];
        await UpdateMetaFrom<TDomain>(dtoInfo, copyMetaType);
    }

    /// <summary> Дополнить метаданные DTO из домена. Данные ДОБАВЛЯЮТСЯ. </summary>
    /// <typeparam name="T">Тип откуда добавляем</typeparam>
    /// <param name="dtoInfo">Обновляемая коллекция</param>
    /// <param name="copyMetaType">"Конфигурация" копирования</param>
    public static async Task UpdateMetaFrom<T>(List<MetaInformation> dtoInfo, EnumCopyMetaType copyMetaType = EnumCopyMetaType.Default)
    {
        var domainInfo = await GetMetainformationForType<T>();

        foreach (var dtoMemberInfo in dtoInfo)
        {
            var domainMemberInfo = domainInfo.FirstOrDefault(x => x.DataField == dtoMemberInfo.DataField);
            if (domainMemberInfo == null)
                continue;

            if (copyMetaType.HasFlag(EnumCopyMetaType.Caption) && string.IsNullOrEmpty(dtoMemberInfo.Caption))
                dtoMemberInfo.Caption = domainMemberInfo.Caption;

            if (copyMetaType.HasFlag(EnumCopyMetaType.MaxLength) && dtoMemberInfo.MaxLen == 0)
                dtoMemberInfo.MaxLen = domainMemberInfo.MaxLen;

            if (copyMetaType.HasFlag(EnumCopyMetaType.Required) && !dtoMemberInfo.IsRequire)
                dtoMemberInfo.IsRequire = domainMemberInfo.IsRequire;
        }
    }

    /// <summary> Генерация "ключа" по классу </summary>
    /// <typeparam name="T">Тип класса</typeparam>
    private static string GenerateKey<T>()
    {
        return typeof(T).FullName ?? typeof(T).Name;
    }
}

/// <summary> "Конфиг" копирования метаданных из домена </summary>
[Flags]
public enum EnumCopyMetaType
{
    /// <summary> По умолчанию обновляем максимальную длину и обязательность </summary>
    Default = MaxLength | Required,

    /// <summary> Заголовок (атрибут Description и т.д.) </summary>
    Caption = 1,

    /// <summary> Максимальная длина поля </summary>
    MaxLength = 2,

    /// <summary> Обязательность поля </summary>
    Required = 4
}

/// <summary> Метаданные </summary>
public class MetaInformation
{
    public MetaInformation(string dataField)
    {
        this.DataField = dataField;
        this.Caption = dataField;
    }

    /// <summary> Имя свойства </summary>
    public string DataField { get; }

    /// <summary> Заголовок </summary>
    public string Caption { get; set; }

    /// <summary> Обязательность поля </summary>
    public bool IsRequire { get; set; }

    /// <summary> Тип поля </summary>
    public string Type { get; set; } = "string";

    /// <summary> Максимальная длина </summary>
    public int MaxLen { get; set; }
    
    /// <summary> Поле только для чтения (блокируется ввод, только отображение) </summary>
    public bool IsReadOnly { get; set; }
}

/// <summary> Объект с метаданными </summary>
/// <typeparam name="T"></typeparam>
public class DataWithMeta<T>
{
    public DataWithMeta(T? entity)
    {
        this.Entity = entity;
        this.Meta = new Dictionary<string, List<MetaInformation>>();
    }
    
    public T? Entity { get; set; }
    
    public Dictionary<string, List<MetaInformation>> Meta { get; set; }
}
