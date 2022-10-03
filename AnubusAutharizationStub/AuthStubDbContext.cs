using Microsoft.EntityFrameworkCore;

namespace AnubusAutharizationStub;

public class AuthStubDbContext : DbContext
{
    public DbSet<UserStub> UsersStub { get; set; } = null!;
}
