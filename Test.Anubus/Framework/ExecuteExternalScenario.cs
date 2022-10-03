using System.Reflection;
using System.Xml.Linq;

namespace TestConsoleTest.Framework;
#pragma warning disable RCS1077 // Optimize LINQ method call.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable RCS1155 // Use StringComparison when comparing strings.


/// <summary> Вспомогательный класс вызова "сценариев из сценариев" </summary>
public class ExecuteExternalScenario
{
    private readonly Func<ITestRunner> _testRunner;

    public ExecuteExternalScenario(Func<ITestRunner> testRunner)
    {
        this._testRunner = testRunner;
    }

    public void ExecuteScenario(string scenarioName, bool asStep)
    {
        var validateScenario = asStep
            ? new Action<Tuple<string, string, Type, MethodInfo>>(x =>
            {
                var attrs = x.Item4.GetCustomAttributes(typeof(CategoryAttribute), true).OfType<CategoryAttribute>();
                if (attrs.All(xx => xx.Name.ToLower() != "степ".ToLower()))
                    throw new IgnoreException("Сценарий с параметрами должен быть помечен как 'степ'");
            })
            : x =>
            {
                var attrs = x.Item4.GetCustomAttributes(typeof(CategoryAttribute), true).OfType<CategoryAttribute>();
                if (attrs.Any(xx => xx.Name.ToLower() == "степ".ToLower()))
                    throw new IgnoreException("Сценарий без параметров НЕ должен быть помечен как 'степ'");
            };


        this.InternalExecuteScenario(scenarioName, validateScenario);
    }


    /// <summary>
    /// Кеш сценариев.
    /// Tuple[Класс, Атрибуты]
    /// </summary>
    private static List<Tuple<string, string, Type, MethodInfo>>? _externalScenarioCache;



    // ReSharper disable once UnusedParameter.Global
    protected void InternalExecuteScenario(string scenarioName, Action<Tuple<string, string, Type, MethodInfo>> validateScenario)
    {
        if (_externalScenarioCache == null)
            FillScenarioCache();
        if (_externalScenarioCache == null)
            throw new IgnoreException("Не инициализирован кеш фич");

        Tuple<string, string, Type, MethodInfo> scenarioInfo;
        if (scenarioName.Contains(":"))
        {
            var split = scenarioName.Split(':');
            if (split.Length != 2)
                throw new IgnoreException("Не верный формат описания Фичи.\n" + scenarioName);

            var feature = split[0].ToLower().Trim();
            var scenario = split[1].ToLower().Trim();

            var allScenarios = _externalScenarioCache.Where(x => x.Item1.ToLower() == feature && x.Item2.ToLower() == scenario).ToList();
            if (allScenarios.Count == 0)
                throw new IgnoreException("Не найден сценарий: " + scenarioName);
            if (allScenarios.Count > 1)
                throw new IgnoreException("Найдено слишком много сценариев: " + scenarioName);

            scenarioInfo = allScenarios.Single();
        }
        else
        {
            var features = _externalScenarioCache.Where(x => x.Item1.ToLower() == scenarioName.Trim().ToLower()).ToList();
            var scenarios = _externalScenarioCache.Where(x => x.Item2.ToLower() == scenarioName.Trim().ToLower()).ToList();
            if (features.Count + scenarios.Count == 0)
                throw new IgnoreException("Не найден сценарий: " + scenarioName);
            if (features.Count + scenarios.Count > 1)
                throw new IgnoreException(string.Format("Найдено слишком много сценариев: {0} Поиск по имени фич: {1} Поиск по имени сценариев: {2}", scenarioName, features.Count, scenarios.Count));

            scenarioInfo = features.SingleOrDefault() ?? scenarios.Single();
        }

        var featureObj = Activator.CreateInstance(scenarioInfo.Item3);
        var piTestRunner = scenarioInfo.Item3.GetField("testRunner", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
        if (piTestRunner != null)
        {
            var alreadySet = piTestRunner.GetValue(featureObj) != null;
            if (!alreadySet)
                piTestRunner.SetValue(featureObj, this._testRunner());
        }
        else
            throw new AssertionException("Не смогли достучаться до testRunner");


        EnterScenario(scenarioInfo.Item1 + ": " + scenarioInfo.Item2);
        try
        {
            scenarioInfo.Item4.Invoke(featureObj, new object[] { });
        }
        catch (TargetInvocationException exception)
        {
            if (exception.InnerException != null)
                throw exception.InnerException;
            throw;
        }
        LeafScenario();
    }

    #region Генерация xmind

    private static XDocument? ExecureTrace { get; set; }

    private static Stack<XElement> StackTrace { get; set; } = new Stack<XElement>();

    /// <summary> Сохранить Xmind </summary>
    public static void SaveXmindInternal(string fileName)
    {
        throw new NotImplementedException("Не сделал ITestContext");

        //var tc = (ITestContext)null;

        //fileName = tc.ReplaceTestString(fileName);

        //ExecureTrace?.Save(fileName);
    }

    private void EnterScenario(string fullScenarioName)
    {
        if (StackTrace == null)
            StackTrace = new Stack<XElement>(30);
        var rnd = new Random();

        XNamespace xmlns = "urn:xmind:xmap:xmlns:content:2.0";

        if (ExecureTrace == null)
        {

            ExecureTrace = new XDocument(
                    new XElement(xmlns + "xmap-content",
                        //new XAttribute("xmlns", "urn:xmind:xmap:xmlns:content:2.0"),
                        //new XAttribute("xmlns:fo", "http://www.w3.org/1999/XSL/Format"), 
                        //new XAttribute("xmlns:svg", "http://www.w3.org/2000/svg"),
                        //new XAttribute("xmlns:xhtml", "http://www.w3.org/1999/xhtml"),
                        //new XAttribute("xmlns:xlink", "http://www.w3.org/1999/xlink"),
                        new XAttribute("version", "2.0"),
                        new XElement(xmlns + "sheet",
                            new XAttribute("id", rnd.Next(100000)),
                            new XElement(xmlns + "title", "Тестовое исполнение"),
                            new XElement(xmlns + "topic",
                                new XElement(xmlns + "title", "Главный титл"),
                                new XElement(xmlns + "children",
                                    new XElement(xmlns + "topics",
                                        new XAttribute("type", "attached")
              ))))));
        }

        var newTopic = new XElement(xmlns + "topic", new XAttribute("id", rnd.Next(100000)), new XElement(xmlns + "title", new XAttribute("id", rnd.Next(100000)), fullScenarioName));

        if (StackTrace.Count != 0)
        {
            var currentStack = StackTrace.Peek();
            var childrenElement = currentStack.Element(xmlns + "children");
            if (childrenElement == null)
            {
                childrenElement = new XElement(xmlns + "children");
                currentStack.Add(childrenElement);
            }

            var topicsElement = childrenElement.Element(xmlns + "topics");
            if (topicsElement == null)
            {
                topicsElement = new XElement(xmlns + "topics", new XAttribute("type", "attached"));
                childrenElement.Add(topicsElement);
            }

            topicsElement.Add(newTopic);
        }
        else
        {
            // ReSharper disable PossibleNullReferenceException
            var mainTitle = ExecureTrace.Element(xmlns + "xmap-content").Element(xmlns + "sheet").Element(xmlns + "topic").Element(xmlns + "children").Element(xmlns + "topics");
            mainTitle.Add(newTopic);
            // ReSharper restore PossibleNullReferenceException
        }

        StackTrace.Push(newTopic);
    }

    private static void LeafScenario()
    {
        StackTrace.Pop();
    }
    #endregion

    private void FillScenarioCache()
    {
        // Фичи, подвластные нам
        var features = this.GetTypes()
                .Select(t => new { T = t, Atts = t.GetCustomAttributes(true).ToList() })
                .Where(t => t.Atts.Any(tt => tt is TestFixtureAttribute) && t.Atts.Any(tt => tt is DescriptionAttribute))
                .Select(t => new { t.T, t.Atts, Desc = t.Atts
                        .OfType<DescriptionAttribute>()
                        .Single()
                        .Properties["Description"]
                        .OfType<string>()
                        .Single() 
                })
                .Where(t => !string.IsNullOrEmpty(t.Desc))
                .ToList();
        // Сценарии, в подвластных фичах
        var scenarios = features.SelectMany(x => x.T.GetMethods().Select(xx => new { F = x, Pi = xx }))
                .Select(x => new { x.F, x.Pi, Attrs = x.Pi.GetCustomAttributes(true).ToList() })
                .Where(x => x.Attrs.Any(pp => pp is TestAttribute) && x.Attrs.Any(pp => pp is DescriptionAttribute))
                .Select(x => new { x.F, x.Pi, Desc = x.Attrs
                        .OfType<DescriptionAttribute>()
                        .Single()
                        .Properties["Description"]
                        .OfType<string>()
                        .Single()
                })
                .Where(x => !string.IsNullOrEmpty(x.Desc))
                .ToList();

        _externalScenarioCache = scenarios.Select(x => new Tuple<string, string, Type, MethodInfo>(x.F.Desc, x.Desc, x.F.T, x.Pi)).ToList();
    }

    private IEnumerable<Type> GetTypes()
    {
        return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a =>
            {
                if (!a.GetName().Name.StartsWith("Test"))
                    return Enumerable.Empty<Type>();

                try
                {
                    return a.GetTypes();
                }
                catch
                {
                    return Enumerable.Empty<Type>();
                }
            }
            );
    }
}
#pragma warning restore RCS1155 // Use StringComparison when comparing strings.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore RCS1077 // Optimize LINQ method call.
