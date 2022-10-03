using Serilog.Events;
using Serilog.Formatting;
using System.Text;

namespace Anubus.Services.Logging;

/// <summary> Форматировщик сообщения для посылки в log2console </summary>
public class LogUdpFormatter : ITextFormatter
{
    public void Format(LogEvent logEvent, TextWriter output)
    {
        var level = logEvent.Level switch
        {
            LogEventLevel.Verbose => "VERBOSE",
            LogEventLevel.Debug => "DEBUG",
            LogEventLevel.Information => "INFO",
            LogEventLevel.Warning => "WARN",
            LogEventLevel.Error => "ERROR",
            LogEventLevel.Fatal => "FATAL",
            _ => throw new NotImplementedException($"Log level: {logEvent.Level}")
        };


        output.WriteLine(
$@"<log4j:event level=""{level}"" timestamp=""{logEvent.Timestamp.ToUnixTimeMilliseconds()}""><log4j:message><![CDATA[{this.RenderMessage(logEvent)}]]></log4j:message>"
//<log4j:throwable><![CDATA[{Environment.StackTrace}]]></log4j:throwable>
+ $"<log4j:properties>{this.FormatException(logEvent)}</log4j:properties>{this.FormatLocation(logEvent)}</log4j:event>");
    }

    public string FormatException(LogEvent logEvent)
    {
        if (logEvent.Exception != null)
        {
            if (logEvent.Exception.StackTrace == null)
            {
                return string.Format("<log4j:data name=\"Exceptions\" value=\"{0}\"/>",
                    logEvent.Exception.ToString());
            }
            else
            {
                return string.Format("<log4j:data name=\"Exceptions\" value=\"{0}\"/>",
                    logEvent.Exception.ToString()
                            .Replace("&", "&amp;")
                            .Replace("<", "&lt;")
                            .Replace(">", "&gt;")
                        );
            }
        }
        else
        {
            //return string.Format("<log4j:data name=\"Exceptions\" value=\"{0}\"/>",
            //    Environment.StackTrace.Replace("<", "&lt;").Replace(">", "&gt;")
            //    .Replace("\n", "").Replace("\r", ""));
            return "";
        }
    }

    private string FormatLocation(LogEvent logEvent)
    {
        if (logEvent.Properties.TryGetValue("CallContext", out var callContextS))
        {
            var callContext = (Serilog.Events.StructureValue)callContextS;
            var memberName = "";
            var sourceFilePath = "";
            var sourceLineNumber = "0";

            foreach (var property in callContext.Properties)
            {
                if (property.Name == "MemberName")
                    memberName = property.Value.ToString();
                else if (property.Name == "FilePath")
                    sourceFilePath = property.Value.ToString();
                if (property.Name == "LineNumber")
                    sourceLineNumber = property.Value.ToString();
            }

            return $@"<log4j:locationInfo class="""" method="""" file={sourceFilePath} line=""{sourceLineNumber}"" />";
        }
        return "";
    }

    private string RenderMessage(LogEvent logEvent)
    {
        // Оценка объёма от балды. Считаю, что размер сообщения увеличиться на 20% + дополняю по 10 символов на property
        var sb = new StringBuilder((int)(logEvent.MessageTemplate.Text.Length * 1.2) + logEvent.Properties.Count * 10);
        var templateProps = new HashSet<string>();

        foreach (var token in logEvent.MessageTemplate.Tokens)
        {
            if (token is Serilog.Parsing.TextToken txtToken)
            {
                sb.Append(txtToken.Text);
            }
            else if (token is Serilog.Parsing.PropertyToken prpToken)
            {
                var prp = logEvent.Properties[prpToken.PropertyName];
                if (prp is ScalarValue sv)
                {
                    sb.Append(sv.Value);
                    templateProps.Add(prpToken.PropertyName);
                }
                else
                {

                }
            }
            else
            {

            }
        }

        sb.AppendLine();
        sb.AppendLine();
        foreach (var prop in logEvent.Properties)
        {
            if (templateProps.Contains(prop.Key))
                continue;

            sb.Append(prop.Key);
            sb.Append(" = [");
            sb.Append(prop.Value);
            sb.Append("]");
            sb.AppendLine();
        }

        return sb.ToString();
    }
}

