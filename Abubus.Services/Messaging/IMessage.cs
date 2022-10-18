namespace Anubus.Services.Messaging;

/// <summary> Сообщение идущее через rabbit </summary>
/// <remarks>
/// Если пошли сообщения, то это надо знать от кого они летят и их номер, поэтому обязательные поля
/// Если потом потребуются системные сообщения, буду делать с пустой строкой
/// </remarks>
public interface IMessage
{
    /// <summary> ИД подключения signalR </summary>
    public string ConnectionId { get; }

    /// <summary> Уникальный ИД операции </summary>
    public string ExecutionId { get; }
}
