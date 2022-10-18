using Anubus.Api.Domain.Spr;
using Microsoft.AspNetCore.Http;
using static Anubus.Api.Controllers.Spr.SprOuNrController;

namespace Anubus.Api.Controllers.Spr;

/// <summary> Справочник ОУНР </summary>
[Route("Spr/OuNr")]
[ApiController]
public class SprOuNrController : SprControllerBase<SprOuNr, SprOuNrListDto, SprOuNrEntityDto>
{
    public SprOuNrController(
            IDbAnubusContextFactory<IGrbsDbContext> dbContextFactory,
            ILogger logger,
            IHttpContextAccessor httpContextAccessor)
        : base(dbContextFactory, logger, CreateMapperConfiguration(), x => x.SprOuNr, httpContextAccessor)
    {
    }

    private static MapperConfiguration CreateMapperConfiguration()
    {
        return new MapperConfiguration(
            c =>
            {
                c.CreateProjection<SprOuNr, SprOuNrListDto>();
                c.CreateProjection<SprOuNr, SprOuNrEntityDto>();
            }
            );
    }

    /// <summary> DTO представления справочника ОУНР </summary>
    public class SprOuNrListDto : SprSimpleListDto
    {
        /// <summary> Резерв </summary>
        [Description("Резерв")]
        public bool IsRezerv { get; set; }
    }

    /// <summary> DTO редактирования справочника ОУНР </summary>
    public class SprOuNrEntityDto : SprSimpleTreeEntityDto
    {
        /// <summary> Резерв </summary>
        [Description("Резерв")]
        public bool IsRezerv { get; set; }

        /// <summary> Скрывать ли заголовок ОУ при формировании телеграммы </summary>
        [Description("Скрывать в телеграмме")]
        public bool TgHide { get; set; }

        /// <summary> Порядок сортировки ОУ при печати телеграммы </summary>
        [Description("Сортировка в телеграмме")]
        public int TgOrder { get; set; }
    }
}
