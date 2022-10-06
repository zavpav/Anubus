using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Anubus.Db;

public static class DbConfiguration
{
    public static void DefaultPgConfiguration<TContext>(this IServiceCollection serviceCollection,
                IConfigurationSection configurationSection)
        where TContext : DbContext
    {
        var host = configurationSection.GetValue<string>("DB_HOST");
        var port = configurationSection.GetValue<int>("DB_PORT");
        var database = configurationSection.GetValue<string>("DB_NAME");
        var username = configurationSection.GetValue<string>("DB_USER");
        var password = configurationSection.GetValue<string>("DB_PASS");

        serviceCollection.AddPooledDbContextFactory<TContext>(opt => opt
                .UseNpgsql($"Host={host};Port={port};Database={database};Username={username};Password={password};Pooling=false;CommandTimeout=300;Timeout=300;KeepAlive=300")
                .AddInterceptors(new DbLogInterceptor(Log.Default))
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging(true)
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
            );
    }
}
