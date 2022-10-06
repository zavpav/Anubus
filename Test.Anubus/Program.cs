using Microsoft.Extensions.Hosting;
using TestConsoleTest.Framework;

var testHost = new TestHostConfiguration();
testHost.Configure(new string[0]);

TestHostConfiguration.ConfiguredHost.Run();