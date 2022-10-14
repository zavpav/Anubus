namespace Anubus.Api.Controllers;

/// <summary> Dto отображения плоского справочника </summary>
public class SprSimpleEntityDto
{
    /// <summary> ИД </summary>
    [Description("ИД")]
    public long Id { get; set; }

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
    [Description("Начало")]
    public DateTime? OnDate { get; set; }

    /// <summary> Дата окончания действия записи (или null, если "вечное") </summary>
    [Description("Конец")]
    public DateTime? ToDate { get; set; }
}

/// <summary> DTO для отображения древовидных сущностей </summary>
public interface ITreeEntityDto
{
    /// <summary> ИД </summary>
    long Id { get; set; }

    /// <summary> Родительский ИД для дерева </summary>
    long? ParentId { get; set; }

    /// <summary> Информация о родителе </summary>
    string? ParentInfo { get; set; }
}

/// <summary> Жирная-DTO для отображения древовидных сущностей </summary>
/// <remarks>Нужно что б не париться со справочниками</remarks>
public interface ITreeEntityFatDto : ITreeEntityDto
{
    /// <summary> Код </summary>
    string Code { get; set; }

    /// <summary> Краткое наименование </summary>
    string ShortName { get; set; }
}

/// <summary> Dto отображения древовидного справочника </summary>
public class SprSimpleTreeEntityDto : ITreeEntityFatDto
{
    /// <summary> ИД </summary>
    [Description("ИД")]
    public long Id { get; set; }

    /// <summary> Родительский ИД для дерева </summary>
    [Description("ИД родителя")]
    [ReadOnly(true)]
    public long? ParentId { get; set; }

    /// <summary> Информация о родителе </summary>
    [Description("Родитель")]
    [ReadOnly(true)]
    public string? ParentInfo { get; set; }

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
    [Description("Начало")]
    public DateTime? OnDate { get; set; }

    /// <summary> Дата окончания действия записи (или null, если "вечное") </summary>
    [Description("Конец")]
    public DateTime? ToDate { get; set; }
}
