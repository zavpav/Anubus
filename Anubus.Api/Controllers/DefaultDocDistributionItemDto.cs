namespace Anubus.Api.Controllers;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

/// <summary> Базовый тип документа представления для редактирования </summary>
public class DefaultDocDistributionItemDto
{
    /// <summary> ИД </summary>
    public long Id { get; set; }

    /// <summary> Номер документа </summary>
    public string? DocNum { get; set; }

    /// <summary> Дата подписи документа исполнителем </summary>
    public DateTime? ApproveDt { get; set; }

    /// <summary> Дата создания документа </summary>
    public DateTime CreateDt { get; set; }

    /// <summary> Статус документа </summary>
    public string DocStatusName { get; set; }

    /// <summary> Коммент </summary>
    public string Descr { get; set; }

    /// <summary> Пользователь, создавший документ </summary>
    public long UserSid { get; set; }

    /// <summary> Распределяемый документом код  </summary>
    public string TopFullSprKey { get; set; }

    /// <summary> Является "первоначальным распределением" </summary>
    public bool IsFirstDistribution { get; set; }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
