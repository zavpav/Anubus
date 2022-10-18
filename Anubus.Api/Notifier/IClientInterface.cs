using Anubus.SignalR;

namespace Anubus.Api.Notifier;

public interface IClientInterface
{
    Task Notify(LongOperationUpdate notifyMessage);
}
