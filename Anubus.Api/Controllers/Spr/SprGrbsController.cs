using Anubus.Api.Domain.Spr;
using DevExtreme.AspNet.Data;

namespace Anubus.Api.Controllers.Spr;

/// <summary> Справочник ГРБС </summary>
[Route("Spr/Grbs")]
[ApiController]
public class SprGrbsController : Controller
{
    private readonly IDbAnubusContextFactory<IGrbsDbContext> _dbContextFactory;
    private readonly ILogger _logger;
    private readonly MapperConfiguration _autoMapperConfiguration;

    public SprGrbsController(IDbAnubusContextFactory<IGrbsDbContext> dbContextFactory, ILogger logger)
    {
        this._dbContextFactory = dbContextFactory;
        this._logger = logger;
        this._autoMapperConfiguration = new MapperConfiguration(
            c =>
            {
                c.CreateProjection<SprGrbs, SprGrbsListDto>();
                c.CreateProjection<SprGrbs, SprGrbsItemDto>();
            }
            );
    }

    #region Работа со списком справочника

    /// <summary> Получить список элементов справочника ГРБС </summary>
    [HttpGet("List")]
    public async Task<IActionResult> List(UserContext userContext, DxDataSourceLoadOptions loadOptions)
    {
        using var dbContext = await this._dbContextFactory.CreateDbContextAsync();

        var source = dbContext.SprGrbs
            .AsNoTracking()
            .ProjectTo<SprGrbsListDto>(this._autoMapperConfiguration);
        var data = await DataSourceLoader.LoadAsync(source, loadOptions);

        return Json(data);
    }

    /// <summary> DTO представления справочника ГРБС </summary>
    public class SprGrbsListDto : SprSimpleDto
    {
    }
    #endregion

    #region Работа с отдельным элементов справочника

    /// <summary> DTO редактирования справочника ГРБС </summary>
    public class SprGrbsItemDto : SprSimpleDto
    {
    }
    #endregion

}
