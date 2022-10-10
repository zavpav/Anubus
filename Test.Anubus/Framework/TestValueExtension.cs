namespace TestConsoleTest;

/// <summary> Набор методов работы с "числами" и прочими "значениями" </summary>
public static class TestValueExtension
{
	/// <summary> Декодировать русское наименование enum </summary>
	/// <typeparam name="T">Тип enum</typeparam>
	/// <param name="rusName">Русское значение enum</param>
	/// <returns>Декодированный enum</returns>
	public static T DecodeEnumValue<T>(string rusName)
		where T : Enum
	{
		return (T)DecodeEnumValue(typeof(T), rusName);
	}

	/// <summary> Декодировать русское наименование enum </summary>
	/// <param name="t">Тип enum</param>
	/// <param name="rusName">Русское значение enum</param>
	/// <returns>Декодированный enum</returns>
	public static object DecodeEnumValue(Type t, string rusName)
	{
        object val;
//        var mainContext = Locator.Resolve<IMainContext>();

        var fieldInfos = Enum.GetValues(t)
                .OfType<object>()
                .Select(x => new { V = x, Pi = t.GetField(x.ToString()!) })
                .Select(x => new
                {
                    x.V,
                    x.Pi,
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    Attrs = x.Pi.GetCustomAttributes(typeof(TestFieldDescriptionAttribute), true).OfType<TestFieldDescriptionAttribute>().Select(xx => xx.RusFieldName)
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                        .Union(x.Pi.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true).OfType<System.ComponentModel.DescriptionAttribute>().Select(xx => xx.Description))
                        //.Union(x.Pi.GetCustomAttributes(typeof(SphaeraDescriptionAttribute), true).OfType<SphaeraDescriptionAttribute>().Where(xx => xx.PossibleProject.Contains(mainContext.Project) || xx.PossibleProject.Contains(EnumProjects.All)).Select(xx => xx.RusName))
                        .ToList()
                })
                .Where(x => x.Attrs != null && x.Attrs.Count > 0)
                .ToList();

        var fieldInfo = fieldInfos.FirstOrDefault(x => x.Attrs.Any(xx => xx.ToLower() == rusName.ToLower()));

        if (fieldInfo == null) // Не нашли по русскому имени. Ищем "в лоб".
            val = Enum.GetValues(t).OfType<object>().FirstOrDefault(xx => xx.ToString()!.ToLower() == rusName.ToLower());
        else
            val = fieldInfo.V;

        if (val == null)
            throw new NotSupportedException("Не получилось декодировать Enum тип: " + t.FullName + "  val: " + rusName);

        return val;
    }

    public static T ParseStringValue<T>(string value)
    {
        var val = ParseStringValue(typeof(T), value);
        return (T)val;
    }

    /// <summary> Разбирает строковое значение свойства и возвращает типизированное, но в виде object. </summary>
    /// <param name="type">PropertyInfo</param>
    /// <param name="value">Строковое значение</param>
    /// <returns>Разобранное значение</returns>
    public static object ParseStringValue(Type type, string value)
    {
        object val;
        if (type == typeof(Int16))
            val = Int16.Parse(value);
        else if (type == typeof(Int32))
            val = Int32.Parse(value);
        else if (type == typeof(Int64))
            val = Int64.Parse(value);
        else if (type == typeof(Double))
            val = value.ParseDecimalIgnoreSeparator();
        else if (type == typeof(Decimal))
            val = value.ParseDecimalIgnoreSeparator();
        else if (type == typeof(DateTime))
        {
            DateTime vdt;
            if (!DateTime.TryParse(value, out vdt))
                throw new FormatException("Ошибка преобразования");
            val = vdt;
        }
        else if (type == typeof(string))
            val = value;
        else if (type.IsEnum)
        {
            val = DecodeEnumValue(type, value);
        }
        else if (type == typeof(bool))
        {
            if (value.ToLower() == "да" || value.ToLower() == "y" || value.ToLower() == "true")
                val = true;
            else if (value.ToLower() == "нет" || value.ToLower() == "n" || value.ToLower() == "false")
                val = false;
            else
                throw new FormatException("Не получилось декодировать Булевый тип: " + value);
        }
        else if (Nullable.GetUnderlyingType(type) != null)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                val = null;
                throw new NotSupportedException("Ошибка декодирования данных (вроде как не может быть null)");
            }
            else
            {
                var propertyType = Nullable.GetUnderlyingType(type);
                CodeStyleExtension.Assert(propertyType != null, "propertyType != null");

                if (propertyType == typeof(Int16))
                    val = Int16.Parse(value);
                else if (propertyType == typeof(Int32))
                    val = Int32.Parse(value);
                else if (propertyType == typeof(Int64))
                    val = Int64.Parse(value);
                else if (propertyType == typeof(Double))
                    val = value.ParseDecimalIgnoreSeparator();
                else if (type == typeof(Decimal))
                    val = value.ParseDecimalIgnoreSeparator();
                else if (propertyType == typeof(DateTime))
                {
                    DateTime vdt;
                    if (!DateTime.TryParse(value, out vdt))
                        throw new FormatException("Ошибка преобразования");
                    val = vdt;
                }
                else if (propertyType == typeof(string))
                    val = value;
                else if (propertyType!.IsEnum)
                    val = DecodeEnumValue(propertyType, value);
                else if (propertyType == typeof(bool))
                {
                    if (value.ToLower() == "да" || value.ToLower() == "y")
                        val = true;
                    else if (value.ToLower() == "нет" || value.ToLower() == "n")
                        val = false;
                    else
                        throw new FormatException("Не получилось декодировать Булевый тип: " + value);
                }
                else
                {
                    throw new FormatException("Не поддерживается тип: " + type.FullName);
                }
            }
        }
        else
        {
            throw new FormatException("Не поддерживается тип: " + type.FullName);
        }
        return val;
    }

    /// <summary> Распарсить объект в число </summary>
    public static decimal ParseDecimalIgnoreSeparator(object value)
    {
        var strVal = value.ToString()!;
        return strVal.ParseDecimalIgnoreSeparator();
    }

    /// <summary>
    /// Распарсить строку в число.
    /// Если из БД.
    /// В качестве разделителя - ТОЧКА или Запятая!
    /// Разделителей групп - НЕТ!
    /// Парсит по стандартным культурам
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="InvalidCastException">Неверный формат числа.</exception>
    public static decimal ParseDecimalIgnoreSeparator(this string value)
    {
        // Парсим "наш" формат
        value = value.Trim(' ', '\t');
        if (Regex.IsMatch(value, @"^\s*-?\d+([,.]\d+)?\s*$"))
            return Decimal.Parse(value
                    .Replace(',', '.')
                    .Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));

        // Парсим
        try { return Decimal.Parse(value, System.Threading.Thread.CurrentThread.CurrentCulture); } catch { }
        try { return Decimal.Parse(value, System.Globalization.CultureInfo.CurrentCulture); } catch { }
//        try { return Decimal.Parse(value, DbFormatProvider.CultureInfo); } catch { }

        throw new InvalidCastException("Неверный формат числа '" + value + "'");

    }
}
