using Anubus.Api.Domain;
using DevExtreme.AspNet.Data;

namespace Anubus.Api.Controllers.Spr
{
    /// <summary> Базовый контроллер простых справочников </summary>
    /// <typeparam name="TDomain">Доменный объект</typeparam>
    /// <typeparam name="TListDto">DTO для списка</typeparam>
    /// <typeparam name="TEntityDto">DTO для редактирования</typeparam>
    public class SprControllerBase<TDomain, TListDto, TEntityDto> : Controller
        where TDomain : class, IEntityBase
        where TListDto : class
        where TEntityDto : class
    {
        private readonly IDbAnubusContextFactory<IGrbsDbContext> _dbContextFactory;
        private readonly ILogger _logger;
        private readonly MapperConfiguration _autoMapperConfiguration;
        private readonly Func<IGrbsDbContext, DbSet<TDomain>> _getDbSet;

        protected SprControllerBase(
            IDbAnubusContextFactory<IGrbsDbContext> dbContextFactory,
            ILogger logger,
            MapperConfiguration autoMapperConfiguration,
            Func<IGrbsDbContext, DbSet<TDomain>> getDbSet
            )
        {
            this._dbContextFactory = dbContextFactory;
            this._logger = logger;
            this._autoMapperConfiguration = autoMapperConfiguration;
            this._getDbSet = getDbSet;
        }

        #region Работа со списком справочника

        /// <summary> Получить список элементов справочника </summary>
        [HttpGet("List")]
        public async Task<IActionResult> List(UserContext userContext, DxDataSourceLoadOptions loadOptions)
        {
            using var dbContext = await this._dbContextFactory.CreateDbContextAsync();

            var source = this._getDbSet(dbContext)
                .AsNoTracking()
                .ProjectTo<TListDto>(this._autoMapperConfiguration);
            var data = await DataSourceLoader.LoadAsync(source, loadOptions);

            return Json(data);
        }

        /// <summary> Получить информацию по колонкам </summary>
        [HttpGet("ListColumnInfo")]
        public async Task<JsonResult> ListColumnInfo(UserContext userContext)
        {
            var meta = await DataWithMetaHelper.GetMetainformationForType<TListDto>();
            await DataWithMetaHelper.UpdateMetaFrom<TDomain>(meta);
            return Json(meta);
        }

        #endregion

        #region Работа с отдельным элементов справочника

        /// <summary> Получить полный элемент справочника </summary>
        [HttpGet("Entity")]
        public async Task<JsonResult> Get(long id, bool withMeta = false)
        {
            using var dbContext = await this._dbContextFactory.CreateDbContextAsync();
            var spr = await this._getDbSet(dbContext)
                    .AsNoTracking()
                    .Where(x => x.Id == id)
                    .ProjectTo<TEntityDto>(this._autoMapperConfiguration)
                    .FirstOrDefaultAsync();

            await this.AdditionalEntityGet(spr, dbContext);

            if (!withMeta)
                return Json(spr);

            var sprWithMetadata = await DataWithMetaHelper.ReturnWithMeta(spr);
            await sprWithMetadata.UpdateMetaFrom<TEntityDto, TDomain>();
            return Json(sprWithMetadata);
        }

        /// <summary> Дополнительно дообработать сущность </summary>
        /// <param name="spr"></param>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        protected async virtual Task AdditionalEntityGet(TEntityDto? spr, IGrbsDbContext dbContext)
        {
            await this.AddEntityTreeInfo(spr, dbContext);
        }

        /// <summary> Добавить информацию по древовидному представлению </summary>
        protected async virtual Task AddEntityTreeInfo(TEntityDto? spr, IGrbsDbContext dbContext)
        {
            if (spr is ITreeEntityFatDto sprTreeFat)
            {
                if (sprTreeFat.ParentId != null)
                {
                    var parentSpr = (ITreeEntityFatDto) await this._getDbSet(dbContext)
                        .AsNoTracking()
                        .Where(x => x.Id == sprTreeFat.ParentId)
                        .ProjectTo<TEntityDto>(this._autoMapperConfiguration)
                        .FirstOrDefaultAsync();
                    if (parentSpr == null)
                        Log.Default.Error("Родительский ИД есть, а данных нет {РодительскийИД}", sprTreeFat.ParentId);
                    else
                        sprTreeFat.ParentInfo = parentSpr.Code + " - " + parentSpr.ShortName;
                }
            } 
            else if (spr is ITreeEntityDto sprTreeUndef)
            {
                if (sprTreeUndef.ParentId != null)
                {
                    var parentSpr = await this._getDbSet(dbContext)
                        .AsNoTracking()
                        .Where(x => x.Id == sprTreeUndef.ParentId)
                        .ProjectTo<TEntityDto>(this._autoMapperConfiguration)
                        .FirstOrDefaultAsync();
                    if (parentSpr == null)
                        Log.Default.Error("Родительский ИД есть, а данных нет {РодительскийИД}", sprTreeUndef.ParentId);
                    else
                    {
                        Log.Default.Error("Не знаю как сформировать информацию по родителю Тип {Тип}", typeof(TEntityDto).FullName);
                        sprTreeUndef.ParentInfo = "Родительская запись с ИД " + sprTreeUndef.ParentId;
                    }
                }
            }
        }

        #endregion
    }
}
