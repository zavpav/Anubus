namespace Anubus.Api.Controllers;

/// <summary> DTO для простых справочников </summary>
public class SprSimpleDto
{
    /// <summary> ИД </summary>
    public long Id { get; set; }

    /// <summary> Родительский ИД для дерева </summary>
    public long? ParentId { get; set; }

    /// <summary> Код </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary> Краткое наименование </summary>
    public string ShortName { get; set; } = string.Empty;

    /// <summary> Полное наименование </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary> Дата начала действия записи (или null, если "вечное") </summary>
    public DateTime? OnDate { get;set; }

    /// <summary> Дата окончания действия записи (или null, если "вечное") </summary>
    public DateTime? ToDate { get; set; }
}
