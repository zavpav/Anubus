namespace TestConsoleTest;

public static class TestHelper
{
    /// <summary> Заменить переменную на её значение </summary>
    /// <param name="variable">Строка, содержащая переменные</param>
    /// <returns>Строка с заменёнными переменными.</returns>
    public static string ReplaceVariable(string variable)
    {
        return Locator.Resolve<ITestExternalStepParameters>().ReplaceParameters(variable);
    }

    /// <summary> Заменить переменную на её значение </summary>
    /// <param name="variable">Строка, содержащая переменные</param>
    /// <param name="additionalParameter">Дополнительные (не только глобальные) параметры перекодирования (т.е. которые передаются не через вызов Выполнить сценарий, а конкретно под этот вызов метода)</param>
    /// <returns>Строка с заменёнными переменными.</returns>
    public static string ReplaceVariable(string variable, Table additionalParameter)
    {
        return Locator.Resolve<ITestExternalStepParameters>().ReplaceParameters(variable, additionalParameter);
    }

    /// <summary> Заменить переменную на её значение </summary>
    /// <param name="variable">Строка, содержащая переменные</param>
    /// <param name="additionalParameter">Дополнительные (не только глобальные) параметры перекодирования (т.е. которые передаются не через вызов Выполнить сценарий, а конкретно под этот вызов метода)</param>
    /// <returns>Строка с заменёнными переменными.</returns>
    public static string ReplaceVariable(string variable, TestTable additionalParameter)
    {
        return Locator.Resolve<ITestExternalStepParameters>().ReplaceParameters(variable, additionalParameter);
    }

    /// <summary> Заменить переменную на её значение </summary>
    /// <param name="variable">Таблица, которую надо пройтись и заменить все строки содержащие переменные.</param>
    /// <returns>Таблица с заменёнными переменными.</returns>
    public static Table ReplaceVariable(Table variable)
    {
        return Locator.Resolve<ITestExternalStepParameters>().ReplaceParameters(variable);
    }

    /// <summary> Заменить переменную на её значение </summary>
    /// <param name="variable">Таблица, которую надо пройтись и заменить все строки содержащие переменные.</param>
    /// <param name="additionalParameter">Дополнительные (не только глобальные) параметры перекодирования (т.е. которые передаются не через вызов Выполнить сценарий, а конкретно под этот вызов метода)</param>
    /// <returns>Таблица с заменёнными переменными.</returns>
    public static Table ReplaceVariable(Table variable, Table additionalParameter)
    {
        return Locator.Resolve<ITestExternalStepParameters>().ReplaceParameters(variable, additionalParameter);
    }

    public static object CreateAndFillSpr(ITestDomainDescription domainDescription, TableRow row)
    {
        var domain = domainDescription.CreateDomain();
        foreach (var key in row.Keys)
            FillSprDomainField(domainDescription, domain, key, row[key]);
        return domain;
    }

    /// <summary> Заполнить доменный объект справочника данными. Имя заполняемого свойства может быть сложным </summary>
    /// <param name="testDomainInform">Информация по доменному объекту</param>
    /// <param name="sprName">Имя справочника</param>
    /// <param name="domain">Заполняемый объект</param>
    /// <param name="key">Имя заполняемого свойства. </param>
    /// <param name="value">Значение свойства</param>
    /// <param name="repository">Репозитарий справочника</param>
    /// <remarks>
    /// Имя заполняемого свойства может быть <br/>
    /// - русским, тогда он его пытается декодировать <br/>
    /// - иметь префикс "@" тогда оно не декодируется, а возвращается "как есть", но без "@"<br/>
    /// - иметь значение "родитель", тогда оно связывается с tsid и заполняется родителем <br/>
    /// - ссылочным: "имя справочника: имя свойства", тогда оно пытается найти ссылку на справочник и привязаться к нужному полю в том справочнике
    /// </remarks>
    public static void FillSprDomainField(ITestDomainDescription domainDescription, object domain, string key, string value)
    {
        if (key.StartsWith("~")) // Игнорим поля
            return;

        if (key.Contains("->"))
        {

            var lst = key.Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
            if (lst.Length != 2)
                return;

            var source = lst[0].Trim();
            var dstFld = lst[1].Trim();

            lst = source.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (lst.Length != 2)
                return;

            var srcSpr = lst[0];
            var srcFld = lst[1];

            var srcRefDomainDesc = TDI.Instance.GetDomainDesc(srcSpr);
            var srcRefFld = srcRefDomainDesc.PropertyInfo(srcFld);
            var exprCompare = TypePropertyHelper.CreateEqual<object>(srcRefDomainDesc.DomainType, srcRefFld.Name, value);

            var data = srcRefDomainDesc.Repository.AllEntities().FirstOrDefault(exprCompare);
            if (data != null)
            {
                var srcRefIdDesc = srcRefDomainDesc.PropertyInfo("ИД");
                var id = srcRefIdDesc.Getter(data);
                var propertyDesc = domainDescription.PropertyInfo(key);
                propertyDesc.Setter(domain, value);
            }
            else
            {
                Log.Default.Error("Не нашли куда хотим ссылаться ");
                throw new TestException("Не нашли куда хотим ссылаться");
            }

            return;
        }

        if (key.ToLower().Trim() == "родитель")
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                try
                {
                    var getCode = domainDescription.PropertyInfo("Код").Getter;
                    var parentSpr = domainDescription.Repository.AllEntities().Single(x => getCode(x).ToString() == value);
                    var getId = domainDescription.PropertyInfo("ИД").Getter;
                    var setParentId = domainDescription.PropertyInfo("Родитель").Setter;
                    setParentId(domain, getId(parentSpr)!.ToString()!);
                }
                catch (InvalidOperationException)
                {
                    throw new IgnoreException("Ошибка поиска родительского элемента " + value);
                }
            }
        }
        else
        {
            var propertyDesc = domainDescription.PropertyInfo(key);

            var pi = propertyDesc.PropertyInfo;
            if (!pi.PropertyType.IsEnum || (pi.PropertyType.IsEnum && value != "")) // Enums ставим только для непустых значений
            {
                if (pi.Name.EndsWith("Id"))
                    Log.Default.Warning("Попытка установить в ссылочное значение {0}.{1} фиксированное значение {2}", domainDescription.RusName, pi.Name, value);

                propertyDesc.Setter(domain, value);
            }
        }
    }

}