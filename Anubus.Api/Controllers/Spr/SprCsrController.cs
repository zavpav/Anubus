using Anubus.Api.Domain.Spr;
using Microsoft.AspNetCore.Http;
using static Anubus.Api.Controllers.Spr.SprCsrController;

namespace Anubus.Api.Controllers.Spr;

/// <summary> Справочник ЦСР </summary>
[Route("Spr/Csr")]
[ApiController]
public class SprCsrController : SprControllerBase<SprCsr, SprCsrListDto, SprCsrEntityDto>
{
    public SprCsrController(
            IDbAnubusContextFactory<IGrbsDbContext> dbContextFactory, 
            ILogger logger,
            IHttpContextAccessor httpContextAccessor)
        : base(dbContextFactory, logger, CreateMapperConfiguration(), x => x.SprCsr, httpContextAccessor)
    {
    }

    private static MapperConfiguration CreateMapperConfiguration()
    {
        return new MapperConfiguration(
            c =>
            {
                c.CreateProjection<SprCsr, SprCsrListDto>();
                c.CreateProjection<SprCsr, SprCsrEntityDto>();
            }
            );
    }

    /// <summary> DTO представления справочника ЦСР </summary>
    public class SprCsrListDto : SprSimpleListDto
    {
    }

    /// <summary> DTO редактирования справочника ЦСР </summary>
    public class SprCsrEntityDto : SprSimpleTreeEntityDto
    {
    }
}
