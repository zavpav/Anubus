using Anubus.Api.Domain.Spr;
using DevExtreme.AspNet.Data;

namespace Anubus.Api.Controllers.Spr;

/// <summary> Справочник РзПрз </summary>
[Route("Spr/RzPrz")]
[ApiController]
public class SprRzPrzController : Controller
{
    private readonly IDbAnubusContextFactory<IGrbsDbContext> _dbContextFactory;
    private readonly ILogger _logger;
    private readonly MapperConfiguration _autoMapperConfiguration;

    public SprRzPrzController(IDbAnubusContextFactory<IGrbsDbContext> dbContextFactory, ILogger logger)
    {
        this._dbContextFactory = dbContextFactory;
        this._logger = logger;
        this._autoMapperConfiguration = new MapperConfiguration(
            c =>
            {
                c.CreateProjection<SprRzPrz, SprRzPrzListDto>();
                c.CreateProjection<SprRzPrz, SprRzPrzItemDto>();
            }
            );
    }

    #region Работа со списком справочника

    /// <summary> Получить список элементов справочника РзПрз </summary>
    [HttpGet("List")]
    public async Task<IActionResult> List(UserContext userContext, DxDataSourceLoadOptions loadOptions)
    {
        using var dbContext = await this._dbContextFactory.CreateDbContextAsync();

        var source = dbContext.SprRzPrz
            .AsNoTracking()
            .ProjectTo<SprRzPrzListDto>(this._autoMapperConfiguration);
        var data = await DataSourceLoader.LoadAsync(source, loadOptions);

        return Json(data);
    }

    /// <summary> DTO представления справочника РзПрз </summary>
    public class SprRzPrzListDto : SprSimpleDto
    {
    }
    #endregion

    #region Работа с отдельным элементов справочника

    /// <summary> DTO редактирования справочника РзПрз </summary>
    public class SprRzPrzItemDto : SprSimpleDto
    {
    }
    #endregion

}
