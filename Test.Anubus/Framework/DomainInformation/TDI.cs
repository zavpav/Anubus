namespace TestConsoleTest;

/// <summary> Получение информации по доменам для тестов </summary>
public static class TDI
{
    private static ITestDomainInformation? _instance;

    public static ITestDomainInformation Instance => _instance ?? (_instance = Locator.Resolve<ITestDomainInformation>());
}
