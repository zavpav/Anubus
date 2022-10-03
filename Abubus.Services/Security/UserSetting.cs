namespace Anubus.Services.Security;

/// <summary> Настройка пользователя </summary>
public class UserSetting
{
    /// <summary> ИД </summary>
    public long Id { get; set; }

    /// <summary> Код </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary> Тип значения </summary>
    public EnumUserSettingType SettingType { get; set; }

    /// <summary> Число </summary>
    public decimal? NumberVal { get; set; }

    /// <summary> Строка </summary>
    public string? StringVal { get; set; }

    /// <summary> Дата </summary>
    public DateTime? DateVal { get; set; }
}
