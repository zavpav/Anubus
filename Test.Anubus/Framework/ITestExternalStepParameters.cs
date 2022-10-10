namespace TestConsoleTest;

public interface ITestExternalStepParameters
{
    /// <summary>
    /// Зарегистрировать внешние параметры
    /// </summary>
    /// <param name="externalData">Таблица с параметрами</param>
    /// <remarks>
    /// Выполняем в параметризованном "Выполняем сценарий '(.*)'"
    /// Повторная инициализация запрещена
    /// </remarks>
    void RegisterExternalStepParemetes(Table externalData);

    /// <summary> Попытаться заменить параметр </summary>
    /// <param name="tryToValue"> Параметр, который надо попробовать заменить </param>
    /// <returns>Если есть, то замененное значение tryToValue, если переменной нет, то само значение tryToValue </returns>
    string ReplaceParameters(string tryToValue);

    /// <summary> Попытаться заменить параметр </summary>
    /// <param name="tryToValue"> Параметр, который надо попробовать заменить </param>
    /// <param name="additionalParameter">Дополнительные переменные, не завязанные на step</param>
    /// <returns>Если есть, то замененное значение tryToValue, если переменной нет, то само значение tryToValue </returns>
    string ReplaceParameters(string tryToValue, Table additionalParameter);

    /// <summary> Попытаться заменить параметр </summary>
    /// <param name="tryToValue"> Параметр, который надо попробовать заменить </param>
    /// <param name="additionalParameter">Дополнительные переменные, не завязанные на step</param>
    /// <returns>Если есть, то замененное значение tryToValue, если переменной нет, то само значение tryToValue </returns>
    string ReplaceParameters(string tryToValue, TestTable additionalParameter);

    /// <summary> Попытаться заменить элементы таблицы </summary>
    /// <param name="tableData"> Таблица, которую надо попробовать обработать </param>
    /// <returns> Таблица с замененными параметрами </returns>
    Table ReplaceParameters(Table tableData);

    /// <summary> Попытаться заменить элементы таблицы </summary>
    /// <param name="tableData"> Таблица, которую надо попробовать обработать </param>
    /// <param name="additionalParameter">Дополнительные переменные, не завязанные на step</param>
    /// <returns> Таблица с замененными параметрами </returns>
    Table ReplaceParameters(Table tableData, Table additionalParameter);

    /// <summary> Очищаем данные </summary>
    void ClearLast();

}

public class TestExternalStepParameters : ITestExternalStepParameters
{
    /// <summary> "Имя" переменной, которая обрабатывается отдельно-отдельно </summary>
    public const string LastPhraseMagicConstant = "<last>";

    /// <summary>
    /// Список словарей замен. Если вложенные вызовы, то они перекрываются.
    /// Func используется для универсальности констант
    /// </summary>
    private static List<Dictionary<string, Func<string, string>>> DataParameters { get; set; }

    /// <summary>
    /// Список замен для констант.
    /// Содержат функции. Не должны содержать прям праметры. 
    /// Т.е. если glodate - то должна быть нормальная функция через Locator получения glodate
    /// </summary>
    private static List<Dictionary<string, Func<string, string>>> DataConstants { get; set; }

    private static int GlobalNextNumber = 10;

    static TestExternalStepParameters()
    {
        DataParameters = new List<Dictionary<string, Func<string, string>>>(5);
        DataConstants = new List<Dictionary<string, Func<string, string>>>
            {
                new Dictionary<string, Func<string, string>>
                {
                    //Названия в lowercase
                    {"<globalintnumber>", x => { GlobalNextNumber++; return GlobalNextNumber.ToString();}},
                    {"<nowdate>", x => DateTime.Now.Date.ToString("dd.MM.yyyy")},
                    {"<now>", x => DateTime.Now.Date.ToString("dd.MM.yyyy HH:mm:ss")},
                    {"<testbinexp>", x => Path.Combine(Locator.Resolve<ITestContext>().BinTestPath, @"TempExp\")},
                    {"<testbin>", x => Locator.Resolve<ITestContext>().BinTestPath},
                    //{"<glodatedate>", x => Locator.Resolve<IMainContext>().Glodate.Date.ToString("dd.MM.yyyy")},
                    //{"<glodate>", x => Locator.Resolve<IMainContext>().Glodate.Date.ToString("dd.MM.yyyy HH:mm:ss")},
                    //{"<firstyear>", x => Locator.Resolve<IMainContext>().FirstYear.ToString(CultureInfo.InvariantCulture)},
                    //{"<global_org_sid>", x =>   ((SprOrganization)Locator.Resolve<IMainContext>().CurrentOrg()).PcbpPsid.ToString()}
                }
            };
    }

    public TestExternalStepParameters()
    {
    }

    public void RegisterExternalStepParemetes(Table externalData)
    {
        if (!externalData.ContainsColumn("Параметр") || !externalData.ContainsColumn("Значение"))
            throw new IgnoreException("Не верная таблица конфигурации внешних переменных");

        var levelData = new Dictionary<string, Func<string, string>>(externalData.RowCount + 1);

        foreach (var tableRow in externalData.Rows)
        {
            try
            {
                var val = tableRow["Значение"];
                levelData.Add(tableRow["Параметр"].ToLower(), x => val);
            }
            catch (Exception ex)
            {
                throw new IgnoreException("Не верная таблица конфигурации внешних переменных: " + tableRow["Параметр"] + " " + ex.Message, ex);
            }
        }

        if (DataParameters.SelectMany(x => x.Keys).Any(levelData.ContainsKey))
            throw new IgnoreException("Ошибка конфигурирования вложенных степов. Совпадают коды: " + string.Join(", ", DataParameters.SelectMany(x => x.Keys).Where(levelData.ContainsKey)));

        DataParameters.Add(levelData);
    }

    public void ClearLast()
    {
        if (!DataParameters.Any())
            throw new IgnoreException("Ошибка инициализации: чистка ");

        DataParameters.Remove(DataParameters.Last());
    }



    private readonly Regex _findVariable = new Regex(@"<<[^>]+>>", RegexOptions.Compiled);
    private readonly Regex _findConstant = new Regex(@"<[^>]+>", RegexOptions.Compiled);


    public Table ReplaceParameters(Table tableData)
    {
        foreach (var tableRow in tableData.Rows)
            foreach (var header in tableData.Header)
                tableRow[header] = this.ReplaceParameters(tableRow[header]);

        return tableData;
    }

    public string ReplaceParameters(string tryToValueOriginal)
    {
        return this.ReplaceParametersInternal(tryToValueOriginal, null);
    }

    public Table ReplaceParameters(Table tableData, Table additionalParameter)
    {
        foreach (var tableRow in tableData.Rows)
            foreach (var header in tableData.Header)
                tableRow[header] = this.ReplaceParameters(tableRow[header], additionalParameter);

        return tableData;
    }

    public string ReplaceParameters(string tryToValueOriginal, Table additionalParameter)
    {
        return this.ReplaceParametersInternal(tryToValueOriginal, additionalParameter);
    }

    public string ReplaceParameters(string tryToValueOriginal, TestTable additionalParameter)
    {
        return this.ReplaceParametersInternal(tryToValueOriginal, additionalParameter.RecodingToSpecflowTable());
    }

    /// <summary> Замена параметров с использованием дополнительного словаря данных (не обязательно) </summary>
    /// <param name="tryToValueOriginal">Строка перекодирования</param>
    /// <param name="additionalParameter">Дополнительная таблица с параметрами замены (не только глобальные, которые идут со степами)</param>
    /// <returns></returns>
    private string ReplaceParametersInternal(string tryToValueOriginal, Table? additionalParameter)
    {
        var value = tryToValueOriginal;
        if (additionalParameter != null)
        {
            if (!additionalParameter.Header.Contains("Параметр"))
                throw new TestException("В дополнительных параметрах вызова не найдена колонка Параметр");

            if (!additionalParameter.Header.Contains("Значение"))
                throw new TestException("В дополнительных параметрах вызова не найдена колонка Значение");


            var additional = new Dictionary<string, Func<string, string>>();

            foreach (var row in additionalParameter.Rows)
            {
                var row1 = row;
                additional.Add("<<" + row1["Параметр"].ToLower() + ">>", x => row1["Значение"]);
            }

            value = ReplaceValuePart(value, this._findVariable, new List<Dictionary<string, Func<string, string>>> { additional });
        }
        value = ReplaceValuePart(value, this._findVariable, DataParameters);

        value = ReplaceValuePart(value, this._findConstant, DataConstants);
        return value;
    }

    private string ReplaceValuePart(string tryToValueOriginal, Regex reFind, List<Dictionary<string, Func<string, string>>> data)
    {
        var tryToValue = tryToValueOriginal.Trim();

        var findVars = reFind.Matches(tryToValue).OfType<Match>().Select(x => x.Value).ToList();
        var isPotentialVariable = findVars.Any();

        if (!data.Any())
        {
            if (isPotentialVariable)
                Log.Default.Information("Очень похоже на внешнюю переменную, но они не сконфигурированы: {TryToValue}", tryToValue);

            return tryToValue;
        }

        foreach (var findVar in findVars)
        {
            Func<string, string>? res = null;

            if (findVar == LastPhraseMagicConstant)
                continue;

            if (!data.Select(x => x.TryGetValue(findVar.ToLower(), out res)).Any(x => x))
                Log.Default.Information("Очень похоже на внешнюю переменную, но она не найдена в списке: {TryToValue}", tryToValue);
            if (res != null)
                tryToValue = tryToValue.Replace(findVar, res(findVar));
        }

        // Вложенные замены.
        if (tryToValue != tryToValueOriginal)
            tryToValue = this.ReplaceValuePart(tryToValue, reFind, data);

        return tryToValue;
    }
}
