using Anubus.Api.Domain.Spr;
using DevExtreme.AspNet.Data;
using static Anubus.Api.Controllers.Spr.SprGrbsController;

namespace Anubus.Api.Controllers.Spr;

/// <summary> Справочник ГРБС </summary>
[Route("Spr/Grbs")]
[ApiController]
public class SprGrbsController : SprControllerBase<SprGrbs, SprGrbsListDto, SprGrbsEntityDto>
{
    public SprGrbsController(IDbAnubusContextFactory<IGrbsDbContext> dbContextFactory, ILogger logger)
        : base(dbContextFactory, logger, CreateMapperConfiguration(), x => x.SprGrbs)
    {
    }

    private static MapperConfiguration CreateMapperConfiguration()
    {
        return new MapperConfiguration(
            c =>
            {
                c.CreateProjection<SprGrbs, SprGrbsListDto>();
                c.CreateProjection<SprGrbs, SprGrbsEntityDto>();
            }
            );
    }

    /// <summary> DTO представления справочника ГРБС </summary>
    public class SprGrbsListDto : SprSimpleListDto
    {
    }

    /// <summary> DTO редактирования справочника ГРБС </summary>
    public class SprGrbsEntityDto : SprSimpleEntityDto
    {
    }
}
