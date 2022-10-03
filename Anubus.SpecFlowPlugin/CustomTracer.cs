using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow.Bindings.Reflection;
using TechTalk.SpecFlow.Tracing;

namespace SpecFlowCustom;
#pragma warning disable Serilog004 // Constant MessageTemplate verifier

public class CustomTracer : ITestTracer
{
    private static int Level = 0;
    private static Regex ReUpLevel = new Regex(@"^Выполняем сценарий '[^']+'$");
    private static int Spaces = 5;

    private static Anubus.ILogger Logger = Anubus.Log.Default;


    [DebuggerStepThrough]
    public void TraceStep(StepInstance stepInstance, bool showAdditionalArguments)
    {
        Logger.Information(new string(' ', Spaces * Level) + (stepInstance.Keyword == "И " ? "    " : "") + "{Степ} [{Фича}: {Сценарий}]",
                            stepInstance.Keyword + " " + stepInstance.Text,
                            stepInstance.StepContext.FeatureTitle,
                            stepInstance.StepContext.ScenarioTitle);

        if (ReUpLevel.IsMatch(stepInstance.Text))
            Level++;
    }

    [DebuggerStepThrough]
    public void TraceWarning(string text)
    {
        if (text == "The previous ScenarioContext was not disposed.")
            return;

        Logger.Warning(text);
    }

    [DebuggerStepThrough]
    public void TraceStepDone(BindingMatch match, object[] arguments, TimeSpan duration)
    {
        if (match.StepBinding.Regex.ToString() == "^Выполняем сценарий '(.*)'$")
            Level--;

        Logger.Information("                                                              Specflow " + new string(' ', Spaces * Level) + "Окончание выполнения " + match.StepBinding.Method.Name + " время " + duration);
    }

    [DebuggerStepThrough]
    public void TraceStepSkipped()
    {
        Logger.Warning("                                                      TraceStepSkipped");
    }

    [DebuggerStepThrough]
    public void TraceStepPending(BindingMatch match, object[] arguments)
    {
        Logger.Warning("                                                      TraceStepPending");
    }

    [DebuggerStepThrough]
    public void TraceBindingError(BindingException ex)
    {
        Logger.Fatal(ex, "Ошибка выполнения тестов TraceBindingError");
    }

    [DebuggerStepThrough]
    public void TraceError(Exception ex, TimeSpan duration)
    {
        Logger.Fatal(ex, "Ошибка выполнения тестов TraceError");
    }

    [DebuggerStepThrough]
    public void TraceNoMatchingStepDefinition(StepInstance stepInstance, ProgrammingLanguage targetLanguage, CultureInfo bindingCulture, List<BindingMatch> matchesWithoutScopeCheck)
    {
        Logger.Fatal("Ошибка-ошибка TraceNoMatchingStepDefinition");
    }

    [DebuggerStepThrough]
    public void TraceDuration(TimeSpan elapsed, IBindingMethod method, object[] arguments)
    {
        Logger.Information("                                                              Specflow " + method.Name + " " + elapsed);
    }

    [DebuggerStepThrough]
    public void TraceDuration(TimeSpan elapsed, string text)
    {
        Logger.Information("                                                              Specflow " + text + " " + elapsed);
    }
}

#pragma warning restore Serilog004 // Constant MessageTemplate verifier
