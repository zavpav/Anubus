namespace Anubus.Services.SignalR;

public class LongOperationDomainError
{
    /// <summary> ИД подключения signalR </summary>
    public string ConnectionId { get; }

    /// <summary> Уникальный ИД операции </summary>
    public string ExecutionId { get; set; }

    /// <summary> Задача закончена </summary>
    public bool IsFinished { get; set; } = true;


    public LongOperationDomainError(string connectionId, string executionId)
    {
        this.ConnectionId = connectionId;
        this.ExecutionId = executionId;
    }

}
