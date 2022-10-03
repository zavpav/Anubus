namespace Anubus.Services.Logging;

/// <summary> Private интерфейс для доступа к логгеру serilog </summary>
public interface ILoggerPrivate
{
    Serilog.ILogger SeriLogger { get; set; }
}
