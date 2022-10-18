using Anubus.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace Anubus.Api.Notifier;

/// <summary> Отсылка уведомлений на клиент </summary>
public interface INotifyClient
{
    /// <summary> Отправить стандартное уведомление </summary>
    /// <param name="notifyMessage">Сообщение (содержит ИД клиента и т.д.)</param>
    Task SendNotify(LongOperationUpdate notifyMessage);
}

/// <summary> Отсылка уведомлений на клиент </summary>
public class NotifyClient : INotifyClient
{
    private IHubContext<NotifyHub, IClientInterface> _signalRContext;

    public NotifyClient(IHubContext<NotifyHub, IClientInterface> signalRContext)
    {
        this._signalRContext = signalRContext;
    }

    public async Task SendNotify(LongOperationUpdate notifyMessage)
    {
        await this._signalRContext
            .Clients
            .Client(notifyMessage.ConnectionId)
            .Notify(notifyMessage);
    }
}
