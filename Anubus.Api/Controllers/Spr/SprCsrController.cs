using Anubus.Api.Domain.Spr;
using static Anubus.Api.Controllers.Spr.SprCsrController;

namespace Anubus.Api.Controllers.Spr;

/// <summary> Справочник ЦСР </summary>
[Route("Spr/Csr")]
[ApiController]
public class SprCsrController : SprControllerBase<SprCsr, SprCsrListDto, SprCsrEntityDto>
{
    public SprCsrController(IDbAnubusContextFactory<IGrbsDbContext> dbContextFactory, ILogger logger)
    : base(dbContextFactory, logger, CreateMapperConfiguration(), x => x.SprCsr)
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
