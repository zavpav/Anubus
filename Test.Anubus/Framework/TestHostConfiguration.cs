using Anubus.Api;
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

                services.AddSingleton<ITestDomainInformation, TestDomainInformation>();
                services.AddTransient<ITestContext, TestConsoleTest.Framework.TestContext>();
            }
            );
        _host = builder.Build();
    }
}
