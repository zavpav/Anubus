using Anubus.Api.Domain.Spr;
using Anubus.Api.Notifier;
using Microsoft.AspNetCore.Http;
using static Anubus.Api.Controllers.Spr.SprGrbsController;

namespace Anubus.Api.Controllers.Spr;

/// <summary> Справочник ГРБС </summary>
[Route("Spr/Grbs")]
[ApiController]
public class SprGrbsController : SprControllerBase<SprGrbs, SprGrbsListDto, SprGrbsEntityDto>
{
    public INotifyClient NotifyClient { get; }

    public SprGrbsController(
            IDbAnubusContextFactory<IGrbsDbContext> dbContextFactory,
            ILogger logger,
            INotifyClient notifyClient,
            IHttpContextAccessor httpContextAccessor)
        : base(dbContextFactory, logger, CreateMapperConfiguration(), x => x.SprGrbs, httpContextAccessor)
    {
        NotifyClient = notifyClient;
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

    protected override Task SendEntityToQueuery(Anubus.SignalR.LongOperationStart longOperation, SprGrbsEntityDto entityDto)
    {

        Task.Run(async () =>
        {
            await Task.Delay(1000);
            var updateOperation = new Anubus.SignalR.LongOperationUpdate(
                longOperation.ConnectionId,
                longOperation.ExecutionId)
            {
                IsFinished = false,
                Message = "Шаг первый"
            };

            //await this.NotifyClient.SendNotify(updateOperation);

            //await Task.Delay(1000);
            //updateOperation = new Anubus.SignalR.LongOperationUpdate(
            //    longOperation.ConnectionId,
            //    longOperation.ExecutionId + "1")
            //{
            //    IsFinished = false,
            //    Message = "Шаг второй"
            //};

            //await this.NotifyClient.SendNotify(updateOperation);

            //await Task.Delay(2000);
            //updateOperation = new Anubus.SignalR.LongOperationUpdate(
            //    longOperation.ConnectionId,
            //    longOperation.ExecutionId)
            //{
            //    IsFinished = false,
            //    Message = "Шаг третий"
            //};

            await this.NotifyClient.SendNotify(updateOperation);

            await Task.Delay(1000);
            updateOperation = new Anubus.SignalR.LongOperationUpdate(
                longOperation.ConnectionId,
                longOperation.ExecutionId)
            {
                IsFinished = true,
                Message = "Конец"
            };
            updateOperation.AddError("code", "Ошибка кода");

            await this.NotifyClient.SendNotify(updateOperation);
        });

        return Task.CompletedTask;
    }

    /// <summary> DTO редактирования справочника ГРБС </summary>
    public class SprGrbsEntityDto : SprSimpleEntityDto
    {
    }
}
