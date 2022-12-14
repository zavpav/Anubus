using Anubus.Api.Domain.Spr;
using Microsoft.AspNetCore.Http;
using static Anubus.Api.Controllers.Spr.SprRzPrzController;

namespace Anubus.Api.Controllers.Spr;

/// <summary> Справочник РзПрз </summary>
[Route("Spr/RzPrz")]
[ApiController]
public class SprRzPrzController : SprControllerBase<SprRzPrz, SprRzPrzListDto, SprRzPrzEntityDto>
{
    public SprRzPrzController(
            IDbAnubusContextFactory<IGrbsDbContext> dbContextFactory,
            ILogger logger,
            IHttpContextAccessor httpContextAccessor)
        : base(dbContextFactory, logger, CreateMapperConfiguration(), x => x.SprRzPrz, httpContextAccessor)
    {
    }

    private static MapperConfiguration CreateMapperConfiguration()
    {
        return new MapperConfiguration(
            c =>
            {
                c.CreateProjection<SprRzPrz, SprRzPrzListDto>();
                c.CreateProjection<SprRzPrz, SprRzPrzEntityDto>();
            }
            );
    }

    /// <summary> DTO представления справочника РзПрз </summary>
    public class SprRzPrzListDto : SprSimpleListDto
    {
    }
    
    /// <summary> DTO редактирования справочника РзПрз </summary>
    public class SprRzPrzEntityDto : SprSimpleTreeEntityDto
    {
    }
}
