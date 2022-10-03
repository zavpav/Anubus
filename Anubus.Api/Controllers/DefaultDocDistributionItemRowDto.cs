namespace Anubus.Api.Controllers;

/// <summary> Базовый тип представления строки документа для редактирования </summary>
public class DefaultDocDistributionItemRowDto
{
    /// <summary> ИД </summary>
    public long Id { get; set; }

    /// <summary> ИД документа </summary>
    public long DocId { get; set; }

    /// <summary> Родительская строка </summary>
    public long? ParentId { get; set; }

    /// <summary> ИД структуры (для "резервов" в распределении по ПБС и т.д. - пусто) </summary>
    public long? StructRowId { get; set; }

    /// <summary> "Код" структуры (ну и какой надо) </summary>
    public string? FullSprKey { get; set; }

    /// <summary> ИД справочника </summary>
    public long SprId { get; set; }

    /// <summary> Наименование справочника </summary>
    public string? SprName { get; set; }

    /// <summary> Сумма БА 1 </summary>
    public decimal SmBa1 { get; set; }

    /// <summary> Сумма БА 2 </summary>
    public decimal SmBa2 { get; set; }

    /// <summary> Сумма БА 3 </summary>
    public decimal SmBa3 { get; set; }

    /// <summary> Сумма ЛБО 1 </summary>
    public decimal SmLbo1 { get; set; }

    /// <summary> Сумма ЛБО 2 </summary>
    public decimal SmLbo2 { get; set; }

    /// <summary> Сумма ЛБО 3 </summary>
    public decimal SmLbo3 { get; set; }

    /// <summary> Сумма ПОФ </summary>
    public decimal SmPof { get; set; }
}
