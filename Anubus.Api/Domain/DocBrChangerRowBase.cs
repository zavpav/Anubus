namespace Anubus.Api.Domain.Docs
{
    public class DocBrChangerRowBase<TDoc, TRow>
        where TDoc : class, IDoc
        where TRow : class
    {
        /// <summary> ИД </summary>
        public long Id { get; set; }

        /// <summary> ИД документа </summary>
        public long DocId { get; set; }

        /// <summary> Документ </summary>
        public TDoc Doc { get; set; } = null!;

        /// <summary> Родительская строка </summary>
        public long? ParentId { get; set; }

        /// <summary> Родительская строка </summary>
        public TRow? Parent { get; set; }

        /// <summary> Дочерние строки </summary>
        public ICollection<TRow> Children { get; set; } = null!;

        /// <summary> ИД структуры (для "резервов" и т.д. - пусто) </summary>
        public long? StructRowId { get; set; }

        /// <summary> "Код" структуры (ну и какой надо) </summary>
        public string? FullSprKey { get; set; }

        /// <summary> ИД справочника </summary>
        public long SprId { get; set; }

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

        /// <summary> Дата изменения записи </summary>
        public DateTime SysChangeDate { get; set; }

        /// <summary> Поколение записи </summary>
        public long Generation { get; set; }
    }
}
