using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Anubus.Db;

public static class DbConfiguration
{
    public static void DefaultPgConfiguration<TContext>(this IServiceCollection serviceCollection,
                string host = "localhost",
                int port = 5441,
                string database = "postgres",
                string username = "postgres",
                string password = "123456")
            where TContext : DbContext
    {
        serviceCollection.AddPooledDbContextFactory<TContext>(opt => opt
                .UseNpgsql($"Host={host};Port={port};Database={database};Username={username};Password={password}")
                .AddInterceptors(new DbLogInterceptor(Log.Default))
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging(true)
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
            );
    }
}
