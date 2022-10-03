using System.Text;

namespace TestConsoleTest.Framework;

public abstract class ExecuteExternalScenarioSteps
{
    protected ExecuteExternalScenarioSteps()
    {
    }

    protected void ExecuteExternalScenarioInternal(string scenarioName, Table parameters)
    {
        if (parameters.Header.Count == 2 && parameters.ContainsColumn("Параметр") && parameters.ContainsColumn("Значение"))
        {
            // Перепаковываем параметры
            var stepParameter = new Table("Параметр", "Значение");
            foreach (var row in parameters.Rows)
                stepParameter.AddRow("<<" + row["Параметр"] + ">>", row["Значение"]);

            this.ExecuteExternalScenarioInternalSingle(scenarioName, stepParameter);
        }
        else
        {
            // Перепаковываем параметры
            foreach (var row in parameters.Rows)
            {
                var stepParameter = new Table("Параметр", "Значение");
                foreach (var col in parameters.Header)
                    stepParameter.AddRow("<<" + col + ">>", row[col]);

                this.ExecuteExternalScenarioInternalSingle(scenarioName, stepParameter);
            }
        }
    }

    private void ExecuteExternalScenarioInternalSingle(string scenarioName, Table parameters)
    {
        var stepParameters = Locator.Resolve<ITestExternalStepParameters>();
        stepParameters.RegisterExternalStepParemetes(parameters);
        var scenarioExecuter = new ExecuteExternalScenario(this.GetTestRunner);
        scenarioExecuter.ExecuteScenario(scenarioName, true);
        stepParameters.ClearLast();
    }

    protected void ExecuteScenarioInternal(string scenarioName)
    {
        var scenarioExecuter = new ExecuteExternalScenario(this.GetTestRunner);
        scenarioExecuter.ExecuteScenario(scenarioName, false);
    }

    /// <summary>
    /// Получить testRunner.
    /// Обязательно должен перегружаться в дочерних классах. Из-за него всё падало.
    /// </summary>
    /// <returns></returns>
    protected abstract ITestRunner GetTestRunner();

    /// <summary> Сохранить информацию XMind </summary>
    protected void SaveXmindInternal(string fileName)
    {
        ExecuteExternalScenario.SaveXmindInternal(fileName);
    }
}
