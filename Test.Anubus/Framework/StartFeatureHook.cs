namespace TestConsoleTest.Framework;

#pragma warning disable RCS1102 // Make class static.
[Binding]
public class StartFeatureHook
#pragma warning restore RCS1102 // Make class static.
{
    [BeforeFeature]
    public static void StartInitialize()
    {
        var testHost = new TestHostConfiguration();
        testHost.Configure(new string[0]);
    }
}
