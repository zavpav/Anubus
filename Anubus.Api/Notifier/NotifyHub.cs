using Microsoft.AspNetCore.SignalR;

namespace Anubus.Api.Notifier;

/// <summary>
/// https://www.c-sharpcorner.com/article/real-time-angular-11-application-with-signalr-and-net-5/
/// </summary>
public class NotifyHub : Hub<IClientInterface>
{
}
