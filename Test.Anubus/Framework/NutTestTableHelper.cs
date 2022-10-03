namespace TestConsoleTest.Framework;

public static class NutTestTableHelper
{
    /// <summary> Перекодирование из TestTable в формат specflow </summary>
    /// <param name="testTable">"Новый" формат таблиц</param>
    /// <returns>"Старый" формат таблиц specflow</returns>
    public static Table RecodingToSpecflowTable(this TestTable testTable)
    {
        var table = new Table(testTable.Headers.ToArray());

        foreach (var row in testTable.Rows())
            table.AddRow(row.NamedCells());

        return table;
    }

    /// <summary> Перекодирование из SpecflowTable в формат TestTable </summary>
    /// <param name="table">Таблица формата specflow</param>
    /// <returns>"Новый формат таблиц"</returns>
    public static TestTable RecodingFromSpecflowTable(this Table table)
    {
        var testTable = new TestTable();

        foreach (var caption in table.Header)
            testTable.AddColumn(caption);

        foreach (var row in testTable.Rows())
            table.AddRow(row.NamedCells());

        return testTable;
    }
}
