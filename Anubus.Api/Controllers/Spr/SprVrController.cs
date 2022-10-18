using Anubus.Api.Domain.Spr;
using Microsoft.AspNetCore.Http;
using static Anubus.Api.Controllers.Spr.SprVrController;

namespace Anubus.Api.Controllers.Spr;

/// <summary> Справочник ВР </summary>
[Route("Spr/Vr")]
[ApiController]
public class SprVrController : SprControllerBase<SprVr, SprVrListDto, SprVrEntityDto>
{
    public SprVrController(
            IDbAnubusContextFactory<IGrbsDbContext> dbContextFactory,
            ILogger logger,
            IHttpContextAccessor httpContextAccessor)
        : base(dbContextFactory, logger, CreateMapperConfiguration(), x => x.SprVr, httpContextAccessor)
    {
    }

    private static MapperConfiguration CreateMapperConfiguration()
    {
        return new MapperConfiguration(
            c =>
            {
                c.CreateProjection<SprVr, SprVrListDto>();
                c.CreateProjection<SprVr, SprVrEntityDto>();
            }
            );
    }

    /// <summary> DTO представления справочника ВР </summary>
    public class SprVrListDto : SprSimpleListDto
    {
    }

    /// <summary> DTO редактирования справочника ВР </summary>
    public class SprVrEntityDto : SprSimpleTreeEntityDto
    {
    }
}
