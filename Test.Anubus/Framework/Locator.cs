namespace TestConsoleTest.Framework;

/// <summary> proxy на старый locater </summary>
public static class Locator
{
    public static T Resolve<T>()
        where T : class
    {
        return null!;
    }
}
