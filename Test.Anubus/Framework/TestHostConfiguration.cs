using Anubus.Api;
using Anubus.Db;
using AnubusAutharizationStub;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TestConsoleTest.Framework;

/// <summary> Стартер приложения </summary>
public class TestHostConfiguration
{
    private static IHost? _host;

    /// <summary> Сконфигурированное приложение </summary>
    public static IHost ConfiguredHost
    {
        get
        {
            if (_host == null)
                throw new NotSupportedException("host не инициализирован");
            return _host;
        }
    }

    /// <summary> Конфигурация приложения </summary>
    public void Configure(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args);
        var startUp = new StartUp(builder, true);

        builder = builder.ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IConfiguration>(hostContext.Configuration);

                startUp.ConfigureLogger(services);
                startUp.ConfigureDatabse(hostContext.Configuration, services);
                startUp.ConfigureWebPartServices(services); //(в тестах не нужна эта регистрация) но она будет пропущена

                // Для тестов база идентификации своя
                ConfigureAuthStubBase(hostContext.Configuration.GetSection("AUTH_STUB_DB"), services);
             
                services.AddSingleton<ITestDomainInformation, TestDomainInformation>();
                services.AddTransient<ITestContext, TestConsoleTest.Framework.TestContext>();
            }
            );
        _host = builder.Build();
    }

    private void ConfigureAuthStubBase(IConfiguration configurationSection, IServiceCollection serviceCollection)
    {
        var host = configurationSection.GetValue<string>("DB_HOST");
        var port = configurationSection.GetValue<int>("DB_PORT");
        var database = configurationSection.GetValue<string>("DB_NAME");
        var username = configurationSection.GetValue<string>("DB_USER");
        var password = configurationSection.GetValue<string>("DB_PASS");

        serviceCollection.AddDbContextFactory<AuthStubDbContext>(opt => opt
                .UseNpgsql($"Host={host};Port={port};Database={database};Username={username};Password={password};Pooling=false;CommandTimeout=300;Timeout=300;KeepAlive=300")
                .AddInterceptors(new DbLogInterceptor(Log.Default))
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging(true)
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
            );

    }
}
