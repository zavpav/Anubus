namespace Anubus.Api.Controllers;

/// <summary> Стандартное DTO для документов-распределений </summary>
public class DefaultDocDistributionListDto
{
    /// <summary> ИД </summary>
    public long Id { get; set; }

    /// <summary> Номер документа </summary>
    public string DocNum { get; set; } = string.Empty;

    /// <summary> Дата подписи документа исполнителем </summary>
    public DateTime? ApproveDt { get; set; }

    /// <summary> Дата создания документа </summary>
    public DateTime CreateDt { get; set; }

    /// <summary> Русское наименование статуса документа </summary>
    public string DocStatusName { get; set; } = string.Empty;

    /// <summary> Коммент </summary>
    public string Descr { get; set; } = string.Empty;

    /// <summary> Пользователь, создавший документ </summary>
    public long UserSid { get; set; }

    /// <summary> Пользователь, создавший документ </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary> Распределяемый документом код  </summary>
    public string TopFullSprKey { get; set; } = string.Empty;

    /// <summary> Допустимые действия для пользователя для объекта </summary>
    public ObjectAction[] Actions { get; set; } = new ObjectAction[0];
}
