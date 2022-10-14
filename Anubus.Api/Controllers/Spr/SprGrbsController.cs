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
                    c.CreateProjection<SprGrbs, SprGrbsEntityDto>();
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
    
    /// <summary> Получить информацию по колонкам </summary>
    [HttpGet("ListColumnInfo")]
    public async Task<JsonResult> ListColumnInfo(UserContext userContext)
    {
        var meta = await DataWithMetaHelper.GetMetainformationForType<SprGrbsListDto>();
        await DataWithMetaHelper.UpdateMetaFrom<SprGrbs>(meta);
        return Json(meta);
    }

    /// <summary> DTO представления справочника ГРБС </summary>
    public class SprGrbsListDto : SprSimpleListDto
    {
    }
    #endregion

    #region Работа с отдельным элементов справочника

    /// <summary> Получить полный элемент справочника </summary>
    [HttpGet("Entity")]
    public async Task<JsonResult> Get(long id, bool withMeta = false)
    {
        using var dbContext = await this._dbContextFactory.CreateDbContextAsync();
        var spr = await dbContext.SprGrbs
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<SprGrbsEntityDto>(this._autoMapperConfiguration)
                .FirstOrDefaultAsync();

        if (!withMeta)
            return Json(spr);

        var sprWithMetadata = await DataWithMetaHelper.ReturnWithMeta(spr);
        await sprWithMetadata.UpdateMetaFrom<SprGrbsEntityDto, SprGrbs>();
        return Json(sprWithMetadata);
    }

    /// <summary> DTO редактирования справочника ГРБС </summary>
    public class SprGrbsEntityDto : SprSimpleEntityDto
    {
    }
    #endregion

}
