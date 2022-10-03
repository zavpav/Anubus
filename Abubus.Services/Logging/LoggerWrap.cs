using Serilog.Events;

#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable Serilog004 // Constant MessageTemplate verifier

namespace Anubus.Services.Logging;

///<summary> Реализация логгера </summary>
///<remarks>
///Почти всё скопировано с serilog.logger что бы не думать над импортом serilog библиотек в соответствующие сервисы
///</remarks>
public class LoggerWrap : Anubus.ILogger, Anubus.Services.Logging.ILoggerPrivate
{
    public Serilog.ILogger _logger;

    public LoggerWrap(Serilog.ILogger logger)
    {
        this._logger = logger;
    }

    public LoggerWrap(Anubus.ILogger logger)
    {
        this._logger = ((ILoggerPrivate)logger).SeriLogger;
    }

    public ILogger ForContext(string propertyName, object? value, bool destructureObjects = false)
    {
        return new LoggerWrap(this._logger.ForContext(propertyName, value, destructureObjects));
    }

    #region LoggerMethods
    public Serilog.ILogger SeriLogger { get => this._logger; set => this._logger = value; }

    private static readonly object[] NoPropertyValues = new object[0];

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Information(string messageTemplate)
    {
        Write(LogEventLevel.Information, messageTemplate, NoPropertyValues);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Information<T>(string messageTemplate, T propertyValue)
    {
        Write(LogEventLevel.Information, messageTemplate, propertyValue);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Information<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {
        Write(LogEventLevel.Information, messageTemplate, propertyValue0, propertyValue1);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Information<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        Write(LogEventLevel.Information, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Information(string messageTemplate, params object?[]? propertyValues)
    {
        Information((Exception?)null, messageTemplate, propertyValues);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Information(Exception? exception, string messageTemplate)
    {
        Write(LogEventLevel.Information, exception, messageTemplate, NoPropertyValues);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Information<T>(Exception? exception, string messageTemplate, T propertyValue)
    {
        Write(LogEventLevel.Information, exception, messageTemplate, propertyValue);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Information<T0, T1>(Exception? exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {
        Write(LogEventLevel.Information, exception, messageTemplate, propertyValue0, propertyValue1);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Information<T0, T1, T2>(Exception? exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        Write(LogEventLevel.Information, exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Information(Exception? exception, string messageTemplate, params object?[]? propertyValues)
    {
        Write(LogEventLevel.Information, exception, messageTemplate, propertyValues);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Warning(string messageTemplate)
    {
        Write(LogEventLevel.Warning, messageTemplate, NoPropertyValues);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Warning<T>(string messageTemplate, T propertyValue)
    {
        Write(LogEventLevel.Warning, messageTemplate, propertyValue);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Warning<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {
        Write(LogEventLevel.Warning, messageTemplate, propertyValue0, propertyValue1);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Warning<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        Write(LogEventLevel.Warning, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Warning(string messageTemplate, params object?[]? propertyValues)
    {
        Warning((Exception?)null, messageTemplate, propertyValues);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Warning(Exception? exception, string messageTemplate)
    {
        Write(LogEventLevel.Warning, exception, messageTemplate, NoPropertyValues);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Warning<T>(Exception? exception, string messageTemplate, T propertyValue)
    {
        Write(LogEventLevel.Warning, exception, messageTemplate, propertyValue);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Warning<T0, T1>(Exception? exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {
        Write(LogEventLevel.Warning, exception, messageTemplate, propertyValue0, propertyValue1);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Warning<T0, T1, T2>(Exception? exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        Write(LogEventLevel.Warning, exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Warning(Exception? exception, string messageTemplate, params object?[]? propertyValues)
    {
        Write(LogEventLevel.Warning, exception, messageTemplate, propertyValues);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Error(string messageTemplate)
    {
        Write(LogEventLevel.Error, messageTemplate, NoPropertyValues);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Error<T>(string messageTemplate, T propertyValue)
    {
        Write(LogEventLevel.Error, messageTemplate, propertyValue);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Error<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {
        Write(LogEventLevel.Error, messageTemplate, propertyValue0, propertyValue1);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Error<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        Write(LogEventLevel.Error, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Error(string messageTemplate, params object?[]? propertyValues)
    {
        Error((Exception?)null, messageTemplate, propertyValues);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Error(Exception? exception, string messageTemplate)
    {
        Write(LogEventLevel.Error, exception, messageTemplate, NoPropertyValues);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Error<T>(Exception? exception, string messageTemplate, T propertyValue)
    {
        Write(LogEventLevel.Error, exception, messageTemplate, propertyValue);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Error<T0, T1>(Exception? exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {
        Write(LogEventLevel.Error, exception, messageTemplate, propertyValue0, propertyValue1);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Error<T0, T1, T2>(Exception? exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        Write(LogEventLevel.Error, exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Error(Exception? exception, string messageTemplate, params object?[]? propertyValues)
    {
        Write(LogEventLevel.Error, exception, messageTemplate, propertyValues);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Fatal(string messageTemplate)
    {
        Write(LogEventLevel.Fatal, messageTemplate, NoPropertyValues);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Fatal<T>(string messageTemplate, T propertyValue)
    {
        Write(LogEventLevel.Fatal, messageTemplate, propertyValue);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Fatal<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {
        Write(LogEventLevel.Fatal, messageTemplate, propertyValue0, propertyValue1);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Fatal<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        Write(LogEventLevel.Fatal, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Fatal(string messageTemplate, params object?[]? propertyValues)
    {
        Fatal((Exception?)null, messageTemplate, propertyValues);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Fatal(Exception? exception, string messageTemplate)
    {
        Write(LogEventLevel.Fatal, exception, messageTemplate, NoPropertyValues);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Fatal<T>(Exception? exception, string messageTemplate, T propertyValue)
    {
        Write(LogEventLevel.Fatal, exception, messageTemplate, propertyValue);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Fatal<T0, T1>(Exception? exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {
        Write(LogEventLevel.Fatal, exception, messageTemplate, propertyValue0, propertyValue1);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Fatal<T0, T1, T2>(Exception? exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        Write(LogEventLevel.Fatal, exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    public void Fatal(Exception? exception, string messageTemplate, params object?[]? propertyValues)
    {
        Write(LogEventLevel.Fatal, exception, messageTemplate, propertyValues);
    }
    #endregion LoggerMethods

    private bool IsEnabled(LogEventLevel level)
    {
        return this._logger.IsEnabled(level);
    }

    #region Internal write methods

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Write(LogEventLevel level, string messageTemplate)
    {
        if (IsEnabled(level))
        {
            Write(level, messageTemplate, NoPropertyValues);
        }
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Write<T>(LogEventLevel level, string messageTemplate, T propertyValue)
    {
        if (IsEnabled(level))
        {
            Write(level, messageTemplate, new object[1]
            {
                    propertyValue
            });
        }
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Write<T0, T1>(LogEventLevel level, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {
        if (IsEnabled(level))
        {
            Write(level, messageTemplate, new object[2]
            {
                    propertyValue0,
                    propertyValue1
            });
        }
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Write<T0, T1, T2>(LogEventLevel level, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        if (IsEnabled(level))
        {
            Write(level, messageTemplate, new object[3]
            {
                    propertyValue0,
                    propertyValue1,
                    propertyValue2
            });
        }
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Write(LogEventLevel level, string messageTemplate, params object?[]? propertyValues)
    {
        Write(level, (Exception?)null, messageTemplate, propertyValues);
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Write(LogEventLevel level, Exception? exception, string messageTemplate)
    {
        if (IsEnabled(level))
        {
            Write(level, exception, messageTemplate, NoPropertyValues);
        }
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Write<T>(LogEventLevel level, Exception? exception, string messageTemplate, T propertyValue)
    {
        if (IsEnabled(level))
        {
            Write(level, exception, messageTemplate, new object[1]
            {
                    propertyValue
            });
        }
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Write<T0, T1>(LogEventLevel level, Exception? exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {
        if (IsEnabled(level))
        {
            Write(level, exception, messageTemplate, new object[2]
            {
                    propertyValue0,
                    propertyValue1
            });
        }
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Write<T0, T1, T2>(LogEventLevel level, Exception? exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        if (IsEnabled(level))
        {
            Write(level, exception, messageTemplate, new object[3]
            {
                    propertyValue0,
                    propertyValue1,
                    propertyValue2
            });
        }
    }

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Write(LogEventLevel level, Exception? exception, string messageTemplate, params object?[]? propertyValues)
    {
        this._logger.Write(level, exception, messageTemplate, propertyValues);
    }
    #endregion Internal write methods
}
#pragma warning restore Serilog004 // Constant MessageTemplate verifier
#pragma warning restore CS8601 // Possible null reference assignment.
