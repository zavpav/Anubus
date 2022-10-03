using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Anubus.Api.Controllers;

/// <summary> Параметры работы с гридом devexpress </summary>
[ModelBinder(BinderType = typeof(DxDataSourceLoadOptionsBinder))]
public class DxDataSourceLoadOptions : DataSourceLoadOptionsBase
{
}

/// <summary> Биндинг параметров получения данных грида devexpress </summary>
public class DxDataSourceLoadOptionsBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var loadOptions = new DxDataSourceLoadOptions();
        DataSourceLoadOptionsParser.Parse(
            loadOptions,
            key => bindingContext.ValueProvider.GetValue(key).FirstOrDefault()
        );
        bindingContext.Result = ModelBindingResult.Success(loadOptions);
        return Task.CompletedTask;
    }
}
