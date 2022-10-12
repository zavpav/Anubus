using Anubus.Api.Domain.Docs.Grbs.ToRezerv;
using DevExtreme.AspNet.Data;

namespace Anubus.Api.Controllers.Grbs;

/// <summary> Распределения в резерв </summary>
[Route("Grbs/ToRezerv")]
[ApiController]
public class DocToRezervController : Controller
{
    private readonly IDbAnubusContextFactory<IGrbsDbContext> _dbContextFactory;
    private readonly MapperConfiguration _autoMapperConfiguration;
    private readonly ILogger _logger;

    public DocToRezervController(IDbAnubusContextFactory<IGrbsDbContext> dbContextFactory, ILogger logger)
    {
        this._dbContextFactory = dbContextFactory;
        this._logger = logger;
        this._autoMapperConfiguration = new MapperConfiguration(
            c =>
            {
                c.CreateProjection<DocToRezerv, DocToRezervListDto>();
                c.CreateProjection<DocToRezerv, DocToRezervItemDto>();
                c.CreateProjection<DocToRezervRow, DocToRezervItemRowDto>();
            }
            );
    }

    /// <summary> Получить ИД БР по данным контекста </summary>
    private long? GetBrId(IGrbsDbContext dbContext, UserContext userContext)
    {
        return dbContext.Brs.Where(x => x.OrgSid == userContext.OrgId
                    && x.Year == userContext.Year
                    && x.BrType == Domain.Brs.EnumBrType.Expense)
                .Select(x => x.Id)
                .SingleOrDefault();
    }

    #region Работа со списком документов

    /// <summary> Получить список всех документов Распределение в резерв </summary>
    [HttpGet("List")]
    public async Task<IActionResult> List(UserContext userContext, DxDataSourceLoadOptions loadOptions)
    {
        using var dbContext = await this._dbContextFactory.CreateDbContextAsync();

        if (userContext.OrgId == null || userContext.Year == null)
        {
            this._logger.Here().Warning("При получении списка документов не задана организация ({OrgId}) или год ({Year})", userContext.OrgId, userContext.Year);

            // Если не задана организация или рабочий год, то не понятно что делать
            return Json("{}");
        }

        var brId = this.GetBrId(dbContext, userContext);
        if (brId == null)
        {
            this._logger.Here().Warning("При получении списка документов не найдена БР для организации ({OrgId}) и года ({Year})", userContext.OrgId, userContext.Year);

            // Если не задана организация или рабочий год, то не понятно что делать
            return Json("{}");
        }

        var source = dbContext.ToRezerv
                .Where(x => x.BrSid == brId.Value)
                .AsNoTracking()
                .ProjectTo<DocToRezervListDto>(this._autoMapperConfiguration);
        var data = await DataSourceLoader.LoadAsync(source, loadOptions);

        if (data.data is List<DocToRezervListDto> rawRad)
            data.data = await this.ListUpdateDto(rawRad);

        return Json(data);
    }

    /// <summary> Обновление "действий" для документов </summary>
    private async Task<List<DocToRezervListDto>> ListUpdateDto(List<DocToRezervListDto> docList)
    {
        await Task.Yield();

        foreach (var doc in docList)
        {
            doc.Actions = new[] {
                new ObjectAction("edit")
        };
        }

        return docList;
    }

    /// <summary> DTO представления документа Распределение в резерв для списка </summary>
    public class DocToRezervListDto : DefaultDocDistributionListDto
    {
    }
    #endregion Работа со списком документов

    #region Работа с отдельным документом
    /// <summary> Получить полный документ </summary>
    [HttpGet("Entity")]
    public async Task<JsonResult> Get(long id, bool withMeta = false)
    {
        using var dbContext = await this._dbContextFactory.CreateDbContextAsync();
        var doc = await dbContext.ToRezerv
                .Include(x => x.Rows)
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<DocToRezervItemDto>(this._autoMapperConfiguration)
                .FirstOrDefaultAsync();

        //var options = new Newtonsoft.Json.JsonSerializerSettings
        //{
        //    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        //};

        if (!withMeta)
            return Json(doc);

        return Json(await DataWithMetaHelper.ReturnWithMeta(doc));
    }

    /// <summary> DTO редактирования документа Распределение в резерв </summary>
    public class DocToRezervItemDto : DefaultDocDistributionItemDto
    {
        public ICollection<DocToRezervItemRowDto> Rows { get; set; } = null!;
    }

    /// <summary> DTO строки документа Распределение в резерв </summary>
    public class DocToRezervItemRowDto : DefaultDocDistributionItemRowDto
    {
    }

    #endregion Работа с отдельным документом

}
