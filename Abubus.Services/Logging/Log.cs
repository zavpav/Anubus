namespace Anubus;

/// <summary> Стандартный логгер </summary>
public static class Log
{
    private static ILogger _default = null!;

    /// <summary> Стандартный логгер </summary>
    /// <remarks>Устанавливается при конфигурации. НЕ ЗАБЫВАТЬ.</remarks>
    public static ILogger Default
    {
        get {
            if (_default == null)
            {
                Console.WriteLine("Must set default configuration as in LoggerConfiguration class");
                Serilog.Log.Logger.Fatal("Must set default configuration as in LoggerConfiguration class");
                throw new Exception("Must set default configuration as in LoggerConfiguration class");
            }
            return _default;
        }
        internal set { _default = value; }
    }
}
