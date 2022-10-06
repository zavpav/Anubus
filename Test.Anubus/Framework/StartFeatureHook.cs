using Ductus.FluentDocker.Builders;
using Ductus.FluentDocker.Commands;
using Ductus.FluentDocker.Services;
using Microsoft.Extensions.Configuration;

namespace TestConsoleTest.Framework;

#pragma warning disable RCS1102 // Make class static.
[Binding]
public class StartFeatureHook
#pragma warning restore RCS1102 // Make class static.
{

    [BeforeFeature]
    public static void StartInitialize()
    {
        var testHost = new TestHostConfiguration();
        testHost.Configure(new string[0]);

        PreparingDatabase();
    }

    [AfterFeature]
    public static void EndFeature()
    {
    }

    /// <summary> Подготовка базы к тестам </summary>
    public static void PreparingDatabase()
    {
        var configuration = (IConfiguration?)TestHostConfiguration.ConfiguredHost.Services.GetService(typeof(IConfiguration))
                            ?? throw new NotSupportedException("Несконфигурирована конфигурация");

        var apiDbSection = configuration.GetSection("API_DB");

        var dbLocalPort = apiDbSection.GetValue<int>("DB_PORT");

        DeleteAnubusTestContainer();

        var containerService = new Builder()
            .UseContainer()
            .UseImage("postgres:14")
            .WithName("anubus-test-db")
            .WithHostName("anubus-test-db")
            .ExposePort(dbLocalPort, 5432)
            .WithEnvironment(
                "POSTGRES_USER=" + apiDbSection.GetValue<string>("DB_USER"),
                "POSTGRES_PASSWORD=" + apiDbSection.GetValue<string>("DB_PASS")
            )
            .WaitForPort(5432 + "/tcp", 30000)
            .Build();
        containerService.Start();

        //TestHostConfiguration.ConfiguredHost.Services.GetService(typeof(IDbContextFactory<AnubusContext>));
    }

    /// <summary> Удалить контейнеры для тестов </summary>
    public static void DeleteAnubusTestContainer()
    {
        var hosts = new Hosts().Discover();
        var docker = hosts.FirstOrDefault(x => x.IsNative) 
                ?? hosts.FirstOrDefault(x => x.Name == "default") 
                ?? throw new NotSupportedException("Ошибка поиска сервисов докера");
        var cont = docker.GetContainers();

        var startedContainers = cont.Where(x => x.Name.StartsWith("anubus-test-")).ToList();
        foreach (var container in startedContainers)
        {
            // !! Тут логгер ещё не стартовал. В логи ничего писать нельзя!
            Console.WriteLine($"Уничтожаем докер-контейнер {container.Name}");
            try
            {
                container.Stop();
            } 
            catch (Exception ex) 
            {
                Console.WriteLine($"Ошибка остановки сервисов докера {container.Name}. Ошибка {ex.Message}");
            }
            try
            {
                docker.Host.RemoveContainer(container.Id, true, true, null);
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка удаления сервисов докера {container.Name}. Ошибка {ex.Message}");
            }
        }

    }
}
