using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Anubus.Db;

public static class DbConfiguration
{
    public static void DefaultPgConfiguration<TContext>(this IServiceCollection serviceCollection,
                IConfiguration configuration)
        where TContext : DbContext
    {
        var section = configuration.GetSection("API_DB");
        
        var host = section.GetValue<string>("DB_HOST");
        var port = section.GetValue<int>("DB_PORT");
        var database = section.GetValue<string>("DB_NAME");
        var username = section.GetValue<string>("DB_USER");
        var password = section.GetValue<string>("DB_PASS");

        serviceCollection.AddPooledDbContextFactory<TContext>(opt => opt
                .UseNpgsql($"Host={host};Port={port};Database={database};Username={username};Password={password}")
                .AddInterceptors(new DbLogInterceptor(Log.Default))
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging(true)
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
            );
    }
}
