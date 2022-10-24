using Anubus.Services.SignalR;

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

    /// <summary> Список доменных ошибок </summary>
    public IReadOnlyDictionary<string, List<string>>? DomainErrors { get { return this._domainErrors; } }

    private Dictionary<string, List<string>>? _domainErrors;

    /// <summary> Добавить ошибку </summary>
    /// <param name="fieldName">Имя поля</param>
    /// <param name="error">Ошибка</param>
    public void AddError(string fieldName, string error)
    {
        fieldName = fieldName.ToLowerFirst();

        var errors = (this.DomainErrors as Dictionary<string, List<string>>) ?? new Dictionary<string, List<string>>();
        if (!errors.TryGetValue(fieldName, out var vals))
            errors.Add(fieldName, new List<string> { error });
        else
            vals.Add(error);

        this._domainErrors = errors;
    }

    public LongOperationUpdate(string connectionId, string executionId)
    {
        this.ConnectionId = connectionId;
        this.ExecutionId = executionId;
    }

}
