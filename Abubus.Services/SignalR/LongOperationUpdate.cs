namespace Anubus.SignalR;

/// <summary> Обновление длительной операции </summary>
public class LongOperationUpdate
{
    /// <summary> ИД подключения signalR </summary>
    public string ConnectionId { get; }

    /// <summary> Уникальный ИД операции </summary>
    public string ExecutionId { get; set; }

    /// <summary> Задача закончена </summary>
    public bool IsFinished { get; set; } = false;

    /// <summary> Текущий шаг </summary>
    public int CurrentStep { get; set; }
    
    /// <summary> Текущая оценка количества шагов </summary>
    public int TotalSteps { get; set; }

    /// <summary> Сообщение пользователю </summary>
    public string? Message { get; set; }

    public LongOperationUpdate(string connectionId, string executionId)
    {
        this.ConnectionId = connectionId;
        this.ExecutionId = executionId;
    }

}
