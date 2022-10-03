namespace Anubus.Services.Security;

/// <summary> Описание настройки, которая есть в системе </summary>
public class UserSettingDesc
{
    /// <summary> Код </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary> Тип значения </summary>
    public EnumUserSettingType SettingType { get; set; }

    /// <summary> Значение по умолчанию для Числа </summary>
    public decimal? DefaultNumberVal { get; set; }

    /// <summary> Значение по умолчанию для Строки </summary>
    public string? DefaultStringVal { get; set; }

    /// <summary> Значение по умолчанию для Даты </summary>
    public DateTime? DefaultDateVal { get; set; }
}
