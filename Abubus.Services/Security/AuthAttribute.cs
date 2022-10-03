using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Anubus.Services.Security;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthAttribute : Attribute, IAuthorizationFilter
{
    private EnumAnubusRole[] _roles = new EnumAnubusRole[0];

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context.ActionDescriptor.EndpointMetadata.Any(x => x.GetType().Equals(typeof(AllowAnonymousAttribute)))) return;

        var services = context.HttpContext.RequestServices;
        var settings = services.GetService(typeof(SecuritySettings)) as SecuritySettings;
        if (settings == null)
            throw new NotSupportedException("Ошибка настроек безопасности");

        //if (settings.WithoutIdm) return; Безопасность должна быть. Не должно быть паролей

        var user = context.HttpContext.Items["User"] as AnubusUser;
        if (user == null)
        {
            // not logged in
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
        else
        {
            //if (_roles != null && !_roles.Any(x => x.Display() == user.Role))
            //{
            //    context.Result = new JsonResult(new { message = "Forbidden" }) { StatusCode = StatusCodes.Status403Forbidden };
            //}
        }

    }


}
