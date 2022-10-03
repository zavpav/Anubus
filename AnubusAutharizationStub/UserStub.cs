using Anubus.Services.Security;

namespace AnubusAutharizationStub;

public class UserStub
{
    public long Id { get; set; }

    public string Login { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public long OrgId { get; set; }

    public EnumAnubusRole[]? Roles { get; set; }
}
