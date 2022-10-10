namespace TestConsoleTest;

/// <summary> proxy на старый locater </summary>
public static class Locator
{
    public static T Resolve<T>()
        where T : class
    {
        return (T)TestHostConfiguration.ConfiguredHost.Services.GetService(typeof(T))
            ?? throw new NotSupportedException("Ошибка получения сервиса " + typeof(T).FullName);
    }
}
