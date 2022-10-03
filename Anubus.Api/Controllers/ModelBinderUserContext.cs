using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Anubus.Api.Controllers;

/// <summary> Пользовательский контекст (год, ид пользователя и т.д) </summary>
[ModelBinder(BinderType = typeof(UserContextBinder))]
public class UserContext
{
    /// <summary> ИД пользователя </summary>
    public long? UserId { get; set; }
    
    /// <summary> ИД организации </summary>
    public long? OrgId { get; set; }
    
    /// <summary> Текущий рабочий год </summary>
    public int? Year { get; set; }
}

/// <summary> Биндинг пользовательского контекста </summary>
public class UserContextBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var usrContext = new UserContext();
        var usrId = bindingContext.ValueProvider.GetValue("user_context_user_id").FirstOrDefault();
        if (usrId != null)
            usrContext.UserId = Convert.ToInt32(usrId);

        var orgId = bindingContext.ValueProvider.GetValue("user_context_org_id").FirstOrDefault();
        if (orgId != null)
            usrContext.OrgId = Convert.ToInt32(orgId);

        var year = bindingContext.ValueProvider.GetValue("user_context_year").FirstOrDefault();
        if (year != null)
            usrContext.Year = Convert.ToInt16(year);

        bindingContext.Result = ModelBindingResult.Success(usrContext);
        return Task.CompletedTask;
    }
}