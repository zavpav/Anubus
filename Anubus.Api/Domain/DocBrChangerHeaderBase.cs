namespace Anubus.Api.Domain.Docs;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class DocBrChangerHeaderBase<TDoc, TRow> : IDoc
    where TDoc : IDoc
    where TRow : class
{
    /// <summary> ИД </summary>
    public long Id { get; set; }

    /// <summary> Номер документа </summary>
    public string DocNum { get;set; }

    /// <summary> Дата подписи документа исполнителем </summary>
    public DateTime? ApproveDt { get; set; }

    /// <summary> Дата создания документа </summary>
    public DateTime CreateDt { get; set; }

    /// <summary> Статус документа </summary>
    public string DocStatus { get; set; }

    /// <summary> Русское наименование статуса документа </summary>
    public string DocStatusName { get; set; } = string.Empty;

    /// <summary> Коммент </summary>
    public string Descr { get; set; } = string.Empty;

    /// <summary> Пользователь, создавший документ </summary>
    public long UserSid { get; set; }

    /// <summary> Организация </summary>
    public long OrgSid { get; set; }

    /// <summary> БР по которой создан документ </summary>
    public long BrSid { get; set; }

    /// <summary> Распределяемый документом код  </summary>
    public long TopBrRowSid { get; set; }

    /// <summary> Распределяемый документом код  </summary>
    public string TopFullSprKey { get; set; }

    /// <summary> Является "первоначальным распределением" </summary>
    public bool IsFirstDistribution { get; set; }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
