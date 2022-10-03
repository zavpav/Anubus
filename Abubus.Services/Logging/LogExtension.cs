using Serilog.Events;
using System.Runtime.CompilerServices;
using System.Text;
using Anubus.Services.Logging;

namespace Anubus;
#pragma warning disable Serilog004 // Constant MessageTemplate verifier

public static class LogExtension
{
    /// <summary> Добавление информации о вызывающем методе (CallContext) </summary>
    public static ILogger Here(this ILogger logger,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    {
        return new LoggerWrap(logger.ForContext("CallContext", new { MemberName = memberName, FilePath = sourceFilePath, LineNumber = sourceLineNumber }, true));
    }

    #region Заглушки на интерполяцию. Ещё подумаю нужны или нет
    [InterpolatedStringHandler]
    public ref struct StructuredLoggingInterpolatedStringHandler
    {
        private readonly StringBuilder _template = null!;
        private readonly List<object?> _arguments = null!;

        public bool IsEnabled { get; }

        public StructuredLoggingInterpolatedStringHandler(int literalLength, int formattedCount, ILogger logger, LogEventLevel logLevel, out bool isEnabled)
        {
            var pLogger = (ILoggerPrivate)logger;

            isEnabled = pLogger.SeriLogger.IsEnabled(logLevel);
            IsEnabled = isEnabled;
            if (isEnabled)
            {
                _template = new(literalLength);
                _arguments = new(formattedCount);
            }
        }

        public void AppendLiteral(string s)
        {
            if (!IsEnabled)
                return;

            _template.Append(s.Replace("{", "{{", StringComparison.Ordinal).Replace("}", "}}", StringComparison.Ordinal));
        }

        public void AppendFormatted<T>(T value, [CallerArgumentExpression("value")] string name = "")
        {
            if (!IsEnabled)
                return;

            _arguments.Add(value);
            _template.Append($"{{@{name}}}");
        }

        public (string, object?[]) GetTemplateAndArguments() => (_template.ToString(), _arguments.ToArray());
    }

    public static void Log(this ILogger logger, LogEventLevel logLevel,
        [InterpolatedStringHandlerArgument("logger", "logLevel")] ref StructuredLoggingInterpolatedStringHandler handler)
    {
        if (handler.IsEnabled)
        {
            var (template, arguments) = handler.GetTemplateAndArguments();
            var pLogger = (ILoggerPrivate)logger;
            pLogger.SeriLogger.Write(logLevel, template, arguments);
        }
    }
    #endregion

    #region Разное по логингу
    //public ref struct Position
    //{

    //    public string MemberName;
    //    public string FilePath;
    //    public int LineNumber;

    //    public Position(string memberName, string sourceFilePath, int sourceLineNumber) : this()
    //    {
    //        this.MemberName = memberName;
    //        this.FilePath = sourceFilePath;
    //        this.LineNumber = sourceLineNumber;
    //    }
    //}

    //public static Position P(
    //    this object t,
    //    [CallerMemberName] string memberName = "",
    //    [CallerFilePath] string sourceFilePath = "",
    //    [CallerLineNumber] int sourceLineNumber = 0)
    //{
    //    return new Position(memberName, sourceFilePath, sourceLineNumber);
    //}

    //public static Position P(
    //    [CallerMemberName] string memberName = "",
    //    [CallerFilePath] string sourceFilePath = "",
    //    [CallerLineNumber] int sourceLineNumber = 0)
    //{
    //    return new Position(memberName, sourceFilePath, sourceLineNumber);
    //}

    //public static void Warn(this Serilog.ILogger logger, Position p, string message)
    //{
    //    logger
    //        .ForContext("CallContext", new { p.MemberName, p.FilePath, p.LineNumber}, true)
    //        .Warning(message);
    //}

    //public static void Warn<T1>(this Serilog.ILogger logger, 
    //        Position p, 
    //        string message, 
    //        T1 p1)
    //{
    //    logger
    //        .ForContext("CallContext", new { p.MemberName, p.FilePath, p.LineNumber }, true)
    //        .Warning(message, p1);
    //}

    //public static void Info(this Serilog.ILogger logger,
    //    string message,
    //    [CallerMemberName] string memberName = "",
    //    [CallerFilePath] string sourceFilePath = "",
    //    [CallerLineNumber] int sourceLineNumber = 0)
    //{
    //    logger
    //        .ForContext("CallContext", new { memberName, sourceFilePath, sourceLineNumber }, true)
    //        .Information(message);
    //}

    //public static void Info<T1> (this Serilog.ILogger logger,
    //    string message,
    //    T1 p1,
    //    [CallerMemberName] string memberName = "",
    //    [CallerFilePath] string sourceFilePath = "",
    //    [CallerLineNumber] int sourceLineNumber = 0)
    //{
    //    logger
    //        .ForContext("CallContext", new { memberName, sourceFilePath, sourceLineNumber }, true)
    //        .ForContext("CallContext2", new System.Diagnostics.StackTrace(), true)
    //        .Information(message, p1);
    //}
    #endregion
}

#pragma warning restore Serilog004 // Constant MessageTemplate verifier