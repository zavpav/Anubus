namespace Anubus.Services.Messaging;

public class Message<TBody> : IMessage
    where TBody : class
{
    /// <summary> ИД подключения signalR </summary>
    public string ConnectionId { get; }

    /// <summary> Уникальный ИД операции </summary>
    public string ExecutionId { get; }

    /// <summary> Данные для обработки </summary>
    public TBody Body { get; set; }

    public Message(string connectionId, string executionId, TBody body)
    {
        this.ConnectionId = connectionId;
        this.ExecutionId = executionId;
        this.Body = body;
    }

}
