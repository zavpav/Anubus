namespace Anubus.Services.Security;

/// <summary> Пользователь </summary>
public class AnubusUser
{
    /// <summary> ИД </summary>
    public long Id { get; set; }

    /// <summary> Логин </summary>
    public string Login { get; set; } = string.Empty;

    /// <summary> Имя </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary> ИД организации </summary>
    public long OrgId { get; set; }

    /// <summary> Список ролей пользователя </summary>
    public EnumAnubusRole[]? Roles { get; set; }
}
