using Microsoft.AspNetCore.Http;
using Serilog.Context;

namespace Anubus.Services.Logging;

public class LogAdditionalInfoMiddleware
{
    private readonly RequestDelegate next;

    public LogAdditionalInfoMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public Task Invoke(HttpContext context)
    {
        var user = context.Items["User"];
        if (user != null)
        {
            LogContext.PushProperty("UserName", user);
        }

        var userAgent = context.Request.Headers["User-Agent"].ToString();
        if (userAgent != null)
        {
            LogContext.PushProperty("UserAgent", userAgent);
        }

        return next(context);
    }
}
