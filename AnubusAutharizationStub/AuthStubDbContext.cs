using Anubus.Services.Security;
using Microsoft.EntityFrameworkCore;

namespace AnubusAutharizationStub;

public class AuthStubDbContext : DbContext
{
    public AuthStubDbContext(DbContextOptions<AuthStubDbContext> options) : base(options)
    {
    }

    public DbSet<UserStub> UsersStub { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder
            .Entity<UserStub>()
            .HasData(new UserStub
            {
                Id = 1,
                Name = "ЦА",
                Login = "ЦА",
                Roles = new[] { EnumAnubusRole.Grbs }
            });

    }
}
