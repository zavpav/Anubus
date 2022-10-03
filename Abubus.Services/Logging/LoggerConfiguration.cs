using Serilog;

namespace Anubus.Services.Logging;

/// <summary> Методы конфигурации логгеров </summary>
public static class LoggerConfiguration
{
    /// <summary> Конфигурация логгеров для web-api </summary>
    public static void ConfigureWebApiPart()
    {
        Serilog.Log.Logger = new Serilog.LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Udp("localhost", 8083, System.Net.Sockets.AddressFamily.InterNetwork, new LogUdpFormatter())
                .CreateLogger();

        Log.Default = new LoggerWrap(Serilog.Log.Logger);
    }
}