using DevExtreme.AspNet.Data;

namespace Anubus.Api.Controllers.Spr
{
    public class SprControllerBase<TDomain, TListDto, TEntityDto> : Controller
        where TDomain : class
        where TListDto : class
        where TEntityDto : class
    {
        private readonly IDbAnubusContextFactory<IGrbsDbContext> _dbContextFactory;
        private readonly ILogger _logger;
        private readonly MapperConfiguration _autoMapperConfiguration;

        protected SprControllerBase(
            IDbAnubusContextFactory<IGrbsDbContext> dbContextFactory, 
            ILogger logger,
            MapperConfiguration autoMapperConfiguration
            )
        {
            this._dbContextFactory = dbContextFactory;
            this._logger = logger;
            this._autoMapperConfiguration = autoMapperConfiguration;
        }

        #region Работа со списком справочника

        /// <summary> Получить список элементов справочника ГРБС </summary>
        [HttpGet("List")]
        public async Task<IActionResult> List(UserContext userContext, DxDataSourceLoadOptions loadOptions)
        {
            using var dbContext = await this._dbContextFactory.CreateDbContextAsync();

            var source = dbContext.SprGrbs
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
            var spr = await dbContext.SprGrbs
                    .AsNoTracking()
                    .Where(x => x.Id == id)
                    .ProjectTo<TListDto>(this._autoMapperConfiguration)
                    .FirstOrDefaultAsync();

            if (!withMeta)
                return Json(spr);

            var sprWithMetadata = await DataWithMetaHelper.ReturnWithMeta(spr);
            await sprWithMetadata.UpdateMetaFrom<TListDto, TDomain>();
            return Json(sprWithMetadata);
        }
        #endregion
    }
}
