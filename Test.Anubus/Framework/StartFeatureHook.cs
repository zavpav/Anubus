using Anubus.Api.Db;
using AnubusAutharizationStub;
using Ductus.FluentDocker.Builders;
using Ductus.FluentDocker.Commands;
using Ductus.FluentDocker.Services;
using Microsoft.EntityFrameworkCore;
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
        DeleteAnubusTestContainer();

        CreateSingleDb<AuthStubDbContext>("AUTH_STUB_DB", "authstubdb");
        CreateSingleDb<AnubusContext>("API_DB", "apidb");
    }

    private static void CreateSingleDb<TContext>(string configSectionName, string dockerConatainerName)
        where TContext : DbContext
    {
        var configuration = (IConfiguration)TestHostConfiguration.ConfiguredHost.Services.GetService(typeof(IConfiguration))
                            ?? throw new NotSupportedException("Несконфигурирована конфигурация");
        var apiDbSection = configuration.GetSection(configSectionName);
        var dbLocalPort = apiDbSection.GetValue<int>("DB_PORT");

        var containerService = new Builder()
            .UseContainer()
            .UseImage("postgres:14")
            .WithName("anubus-test-" + dockerConatainerName)
            .WithHostName("anubus-test-" + dockerConatainerName)
            .ExposePort(dbLocalPort, 5432)
            .WithEnvironment(
                "POSTGRES_USER=" + apiDbSection.GetValue<string>("DB_USER"),
                "POSTGRES_PASSWORD=" + apiDbSection.GetValue<string>("DB_PASS")
            )
            .WaitForPort(5432 + "/tcp", 30000)
            .Build();
        containerService.Start();

        Thread.Sleep(1000);

        try
        {
            var dbContextFactory = (IDbContextFactory<TContext>?)TestHostConfiguration.ConfiguredHost.Services.GetService(typeof(IDbContextFactory<TContext>))
                ?? throw new NotSupportedException("Несконфигурирована фабрика баз"); ;
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                Log.Default.Here().Warning("Пересоздание базы {ConfigSectionName} {DbContext}",
                    configSectionName,
                    dbContext.GetType().Name);
                dbContext.Database.Migrate();
            }
        }
        catch (Exception ex)
        {
            Log.Default.Here().Error(ex, "Пересоздание базы {ConfigSectionName}", 
                configSectionName);

            throw;
        }
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
