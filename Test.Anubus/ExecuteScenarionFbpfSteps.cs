using TestConsoleTest.Framework;

namespace ConsoleTest;

[Binding]
public class ExecuteScenarionFbpfSteps : ExecuteExternalScenarioSteps
{
    [StepDefinition("Выполняем сценарий '(.*)'")]
    [StepDefinition("Выполняем сценарий \"(.*)\"")]
    public void ExecuteExternalScenario(string scenarioName, Table parameters)
    {
        this.ExecuteExternalScenarioInternal(scenarioName, parameters);
    }

    [StepDefinition("Выполняем сценарий '(.*)'")]
    [StepDefinition("Выполняем сценарий \"(.*)\"")]
    public void ExecuteExternalScenario(string scenarioName)
    {
        this.ExecuteScenarioInternal(scenarioName);
    }

    protected override ITestRunner GetTestRunner()
    {
        return TestRunnerManager.GetTestRunner();
    }
}
