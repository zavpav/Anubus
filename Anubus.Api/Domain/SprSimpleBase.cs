namespace Anubus.Api.Domain;

/// <summary> Базовый класс для справочника </summary>
public class SprSimpleBase : IEntityBase
{
    /// <summary> ИД </summary>
    [Description("ИД")]
    public long Id { get; set; }

    /// <summary> Родительский ИД для дерева </summary>
    [Description("Родитель")]
    public long? ParentId { get; set; }

    /// <summary> Код </summary>
    [Description("Код")]
    public string Code { get; set; } = string.Empty;

    /// <summary> Краткое наименование </summary>
    [Description("Краткое наименование")]
    public string ShortName { get; set; } = string.Empty;

    /// <summary> Полное наименование </summary>
    [Description("Полное наименование")]
    public string FullName { get; set; } = string.Empty;

    /// <summary> Дата начала действия записи (или null, если "вечное") </summary>
    [Description("Дата начала")]
    [TestFieldDescription("Начало")]
    public DateTime? OnDate { get; set; }

    /// <summary> Дата окончания действия записи (или null, если "вечное") </summary>
    [Description("Дата окончания")]
    [TestFieldDescription("Конец")]
    public DateTime? ToDate { get; set; }
}
