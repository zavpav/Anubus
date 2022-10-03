namespace Anubus;

public interface ILogger
{
    ILogger ForContext(string propertyName, object? value, bool destructureObjects = false);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Information(string messageTemplate);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Information<T>(string messageTemplate, T propertyValue);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Information<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Information<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Information(string messageTemplate, params object?[]? propertyValues);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Information(Exception? exception, string messageTemplate);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Information<T>(Exception? exception, string messageTemplate, T propertyValue);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Information<T0, T1>(Exception? exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Information<T0, T1, T2>(Exception? exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Information(Exception? exception, string messageTemplate, params object?[]? propertyValues);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Warning(string messageTemplate);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Warning<T>(string messageTemplate, T propertyValue);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Warning<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Warning<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Warning(string messageTemplate, params object?[]? propertyValues);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Warning(Exception? exception, string messageTemplate);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Warning<T>(Exception? exception, string messageTemplate, T propertyValue);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Warning<T0, T1>(Exception? exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Warning<T0, T1, T2>(Exception? exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Warning(Exception? exception, string messageTemplate, params object?[]? propertyValues);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Error(string messageTemplate);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Error<T>(string messageTemplate, T propertyValue);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Error<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Error<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Error(string messageTemplate, params object?[]? propertyValues);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Error(Exception? exception, string messageTemplate);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Error<T>(Exception? exception, string messageTemplate, T propertyValue);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Error<T0, T1>(Exception? exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Error<T0, T1, T2>(Exception? exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Error(Exception? exception, string messageTemplate, params object?[]? propertyValues);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Fatal(string messageTemplate);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Fatal<T>(string messageTemplate, T propertyValue);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Fatal<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Fatal<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Fatal(string messageTemplate, params object?[]? propertyValues);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Fatal(Exception? exception, string messageTemplate);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Fatal<T>(Exception? exception, string messageTemplate, T propertyValue);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Fatal<T0, T1>(Exception? exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Fatal<T0, T1, T2>(Exception? exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2);

    [Serilog.Core.MessageTemplateFormatMethod("messageTemplate")]
    void Fatal(Exception? exception, string messageTemplate, params object?[]? propertyValues);
}
