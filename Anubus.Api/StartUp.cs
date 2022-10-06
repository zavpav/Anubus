using Anubus.Db;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Anubus.Api;


/// <summary> Класс конфигурации. Нужен, потому что может использоваться в тестах </summary>
public class StartUp
{
    private readonly IHostBuilder _hostBuilder;
    private readonly bool _skipWebData;

    /// <summary> Конфигурация приложения </summary>
    /// <param name="hostBuilder">host</param>
    /// <param name="skipWebData">Пропускать то что я отношу к web (для запуска в тестах)</param>
    public StartUp(IHostBuilder hostBuilder, bool skipWebData = false)
    {
        this._hostBuilder = hostBuilder;
        this._skipWebData = skipWebData;
    }

    /// <summary> ПЕРВЫЙ ШАГ!! Конфигурация логгера </summary>
    public void ConfigureLogger(IServiceCollection services)
    {
        Anubus.Services.Logging.LoggerConfiguration.ConfigureWebApiPart();

        Log.Default.Here().Fatal("Start Anubus");

        if (!this._skipWebData)
            Serilog.SerilogHostBuilderExtensions.UseSerilog(this._hostBuilder);

        services.AddTransient<Anubus.ILogger>(_ => Log.Default);
    }

    /// <summary> Конфигурация БД </summary>
    public void ConfigureDatabse(IConfiguration configuration, IServiceCollection services)
    {
        services.DefaultPgConfiguration<AnubusContext>(configuration.GetSection("API_DB"));
        services.AddTransient<IDbAnubusContextFactory<IGrbsDbContext>>(
            s => new DbAnubusContextFactory<IGrbsDbContext, AnubusContext>(s.GetRequiredService<IDbContextFactory<AnubusContext>>()));
    }

    /// <summary> Конфигурация сервисов в части web </summary>
    public void ConfigureWebPartServices(IServiceCollection services)
    {
        if (this._skipWebData)
            return;

        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename), includeControllerXmlComments: true);
        });
    }
}
