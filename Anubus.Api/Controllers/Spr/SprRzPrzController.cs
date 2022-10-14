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
                c.CreateProjection<SprRzPrz, SprRzPrzEntityDto>();
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

    /// <summary> Получить информацию по колонкам </summary>
    [HttpGet("ListColumnInfo")]
    public async Task<JsonResult> ListColumnInfo(UserContext userContext)
    {
        var meta = await DataWithMetaHelper.GetMetainformationForType<SprRzPrzListDto>();
        await DataWithMetaHelper.UpdateMetaFrom<SprRzPrz>(meta);
        return Json(meta);
    }

    /// <summary> DTO представления справочника РзПрз </summary>
    public class SprRzPrzListDto : SprSimpleListDto
    {
    }
    #endregion

    #region Работа с отдельным элементов справочника

    /// <summary> Получить полный элемент справочника </summary>
    [HttpGet("Entity")]
    public async Task<JsonResult> Get(long id, bool withMeta = false)
    {
        using var dbContext = await this._dbContextFactory.CreateDbContextAsync();
        var spr = await dbContext.SprRzPrz
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<SprRzPrzEntityDto>(this._autoMapperConfiguration)
                .FirstOrDefaultAsync();

        if (spr?.ParentId != null)
        {
            var parentSpr = await dbContext.SprRzPrz
                .AsNoTracking()
                .Where(x => x.Id == spr.ParentId)
                .ProjectTo<SprRzPrzEntityDto>(this._autoMapperConfiguration)
                .FirstOrDefaultAsync();
            if (parentSpr == null)
                Log.Default.Error("Родительский ИД есть, а данных нет {РодительскийИД}", spr?.ParentId);
            else
                spr.ParentInfo = parentSpr.Code + " - " + parentSpr.ShortName;
        }

        if (!withMeta)
            return Json(spr);

        var sprWithMetadata = await DataWithMetaHelper.ReturnWithMeta(spr);
        await sprWithMetadata.UpdateMetaFrom<SprRzPrzEntityDto, SprRzPrz>();

        return Json(sprWithMetadata);
    }

    /// <summary> DTO редактирования справочника РзПрз </summary>
    public class SprRzPrzEntityDto : SprSimpleTreeEntityDto
    {
    }
    #endregion

}
