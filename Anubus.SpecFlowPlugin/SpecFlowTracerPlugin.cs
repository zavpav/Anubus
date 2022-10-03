using TechTalk.SpecFlow.Plugins;
using TechTalk.SpecFlow.Tracing;
using TechTalk.SpecFlow.UnitTestProvider;

[assembly: RuntimePlugin(typeof(SpecFlowCustom.SpecFlowTracerPlugin))]

namespace SpecFlowCustom;

//https://github.com/SpecFlowOSS/SpecFlow-Examples/tree/master/Plugins

public class SpecFlowTracerPlugin : IRuntimePlugin
{
    public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters, UnitTestProviderConfiguration unitTestProviderConfiguration)
    {
        runtimePluginEvents.CustomizeTestThreadDependencies += (sender, args) =>
        {
            args.ObjectContainer.RegisterTypeAs<CustomTracer, ITestTracer>();
        };
    }
}
