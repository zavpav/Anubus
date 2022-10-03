namespace TestConsoleTest.Framework;

public class TestTable
{
    private List<string> _headers = new List<string>();

    private List<TestRow> _table = new List<TestRow>();

    public IEnumerable<string> Headers { get { return this._headers; } }

    /// <summary> Добавить колонку в конец </summary>
    /// <param name="caption"></param>
    public void AddColumn(string caption)
    {
        this._headers.Add(caption);
        foreach (var row in this._table)
            row.AddEmptyValue();
    }

    /// <summary> Строчки "таблицы" </summary>
    public IEnumerable<TestRow> Rows()
    {
        return this._table;
    }

    public TestRow AddEmptyRow()
    {
        var addEmptyRow = new TestRow(this);
        for (var i = 0; i < this._headers.Count; i++)
            addEmptyRow.AddEmptyValue();

        this._table.Add(addEmptyRow);
        return addEmptyRow;
    }

    /// <summary> Добавление "заполненной" колонки </summary>
    public TestRow AddRow(params string[] vals)
    {
        if (this._headers.Count != vals.Length)
            throw new NotSupportedException("Количество значений не совпадает с количеством колонок");

        var addRow = new TestRow(this);
        for (var i = 0; i < this._headers.Count; i++)
            addRow.AddValue(vals[i]);

        this._table.Add(addRow);
        return addRow;
    }

    public class TestRow
    {
        /// <summary> Владелец </summary>
        private TestTable Owner { get; set; }

        /// <summary> Значения </summary>
        private List<string> _values = new List<string>();

        internal TestRow(TestTable owner)
        {
            this.Owner = owner;
        }

        internal void AddEmptyValue()
        {
            this._values.Add(string.Empty);
        }

        internal void AddValue(string val)
        {
            this._values.Add(val);
        }

        /// <summary> Получить "словарь" данных. Они неизменяемый </summary>
        public IDictionary<string, string> NamedCells()
        {
            var headers = this.Owner._headers;
            if (headers.Count != this._values.Count)
                throw new NotSupportedException("Ошибка данных");

            return headers.Zip(this._values, (k, v) => Tuple.Create(k, v)).ToDictionary(x => x.Item1, x => x.Item2);
        }

        public IEnumerable<string> Cells()
        {
            return this._values;
        }

        public string this[int colIdx]
        {
            get
            {
                if (colIdx >= this._values.Count)
                    throw new NotSupportedException("Индекс больше количества колонок");

                return this._values[colIdx];
            }

            set
            {
                if (colIdx >= this._values.Count)
                    throw new NotSupportedException("Индекс больше количества колонок");

                this._values[colIdx] = value;
            }
        }

        public string this[string colName]
        {
            get
            {
                var colIdx = this.Owner.FindColumnIndex(colName);
                return this._values[colIdx];
            }

            set
            {
                var colIdx = this.Owner.FindColumnIndex(colName);
                this._values[colIdx] = value;
            }
        }


        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("|");
            foreach (var value in this._values)
            {
                sb.Append(" ");
                sb.Append(value);
                sb.Append(" |");
            }

            return sb.ToString();
        }

    }

    private int FindColumnIndex(string colName)
    {
        var idx = this._headers.IndexOf(colName);
        if (idx < 0)
            throw new NotSupportedException("Ошибка поиска индекса для колонки " + colName);
        return idx;
    }
}
