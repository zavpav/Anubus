namespace Anubus.SignalR;

/// <summary> Результат, возвращаемый на "длительную операцию" (по поводу которой будут приходить сообщения на клиент через signalR) </summary>
public class LongOperationStart
{
    /// <summary> ИД подключения signalR </summary>
    public string ConnectionId { get; }

    /// <summary> Уникальный ИД операции </summary>
    public string ExecutionId { get; set; }

    /// <summary> Является простым ожиданием (надо поднять простую крутилку) </summary>
    public bool IsSimpleWait { get; set; } = true;

    /// <summary> Ориентировочное количество шагов </summary>
    public int TotalSteps { get; set; }

    /// <summary> Сообщение пользователю </summary>
    public string? Message { get; set; }

    public LongOperationStart(string connectionId, string executionId)
    {
        this.ConnectionId = connectionId;
        this.ExecutionId = executionId;
    }
}
