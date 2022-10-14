using System.ComponentModel.DataAnnotations;

namespace Anubus.Api.Domain.Spr;

public class SprGrbs : IEntityBase
{
    /// <summary> ИД </summary>
    [Description("ИД")]
    public long Id { get; set; }

    /// <summary> Код </summary>
    [Description("Код")]
    [MaxLength(3)]
    public string Code { get; set; } = string.Empty;

    /// <summary> Краткое наименование </summary>
    [Description("Краткое наименование")]
    [MaxLength(150)]
    public string ShortName { get; set; } = string.Empty;

    /// <summary> Полное наименование </summary>
    [Description("Полное наименование")]
    [MaxLength(150)]
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
