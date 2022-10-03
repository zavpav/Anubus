namespace Anubus.Api.Domain.Docs;

/// <summary> Документ с одной физической спецификацией (все наши документы-распределения) </summary>
public class DocBrChangerHeaderSingleSpecBase<TDoc, TRow> : DocBrChangerHeaderBase<TDoc, TRow>
    where TDoc : IDoc
    where TRow : class
{
    /// <summary> Список строк </summary>
    public ICollection<TRow>? Rows { get; set; }
}
