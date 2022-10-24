namespace Anubus.Services.SignalR;

/// <summary> Информация по доменной ошибке, отправляемая через signalR </summary>
/// <remarks>
/// Пока не знаю что хочу, поэтому решил сделать просто имя свойства и список ошибок в виде списка
/// </remarks>
public struct DomainErrorInfo
{
    public DomainErrorInfo(string fieldName, string error)
    {
        this.FieldName = fieldName;
        this.Errors.Add(error);
    }

    public DomainErrorInfo(string fieldName, IEnumerable<string> errors)
    {
        this.FieldName = fieldName;
        this.Errors.AddRange(errors);
    }

    /// <summary> Имя свойства </summary>
    /// <remarks>
    /// TODO (Dto? Entity? не знаю пока. Клиентское или серверное название? А что с перекодировкой?)
    /// </remarks>
    public string FieldName { get; set; } = string.Empty;

    /// <summary> Текстовое описание ошибки </summary>
    public List<string> Errors { get; set; } = new List<string>();
}