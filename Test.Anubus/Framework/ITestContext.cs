namespace TestConsoleTest.Framework;


public interface ITestContext
{
	//[NotNull]
	//string MainAppPath { get; }

	string BinTestPath { get; }

	string ReplaceTestString(string testPath);

	void RecreateTempDir();
}

public class TestContext : ITestContext
{
	public TestContext()
	{
		//// Пути поиска файла с меню....
		//// TODO надо что-то сделать вместо этого куска
		//var startupPaths = new List<string>
		//{
		//	@"D:\Projects\fsf\trunc\CS\Sphaera.Bp\bin\Debug\",
		//	@"C:\Autobuilder\fsf\Checkout\CS\Sphaera.Bp\bin\Debug\",
		//	@"C:\Work\ASUD\src\CS\Sphaera.Bp\bin\Debug\",
		//	@"C:\Users\maxim.lapotkov\Projects\SphaeraBp\bin\Debug\",
		//	@"C:\Checkout\bin\Debug\",
		//	@"C:\distr\CurrentSBF\Client\", // Для Саши
		//	@"C:\Work\FBPF\Client\" // Для Руслана
		//};
		//var possibleMainAppPath = startupPaths.Where(x => Directory.Exists(Path.Combine(x, @"Configurator\"))).ToList();
		//if (!possibleMainAppPath.Any())
		//	throw new IgnoreException("Не найден путь к основному приложению");
		//if (possibleMainAppPath.Skip(1).Any())
		//	throw new IgnoreException("Конфликт путей к основному приложению (больше 1)");

		//var mainAppPath = possibleMainAppPath.Single();

		//// Ищем откуда запускаемся.
		//this.MainAppPath = mainAppPath;
		//this.BinTestPath = mainAppPath.Replace(@"\bin\", @"\bintest\");

		//// Для Саши
		//if (this.MainAppPath == @"C:\distr\CurrentSBF\Client\")
		//	this.BinTestPath = @"C:\distr\CurrentSBF\Test\";

		//// Для Руслана
		//if (this.MainAppPath == @"C:\Work\FBPF\Client\")
		//	this.BinTestPath = @"C:\Work\FBPF\Test\";

		this.BinTestPath = Environment.CurrentDirectory;

		var tempPath = Path.Combine(this.BinTestPath, @"TempExp\");
		if (!Directory.Exists(tempPath))
			Directory.CreateDirectory(tempPath);
	}

	public string BinTestPath { get; private set; }

	public string ReplaceTestString(string testPath)
	{
		testPath = testPath.Replace("<TestBinExp>", Path.Combine(this.BinTestPath, @"TempExp\")).Trim();
		testPath = testPath.Replace("<TestBin>", this.BinTestPath).Trim();
		//testPath = testPath.Replace("<MainApp>", this.MainAppPath).Trim();

		return testPath;
	}

	public void RecreateTempDir()
	{
		var tempPath = Path.Combine(this.BinTestPath, @"TempExp\");
		if (Directory.Exists(tempPath)) // Жестко прибиваем директорию
			Directory.Delete(tempPath, true);

		Directory.CreateDirectory(tempPath);
	}
}
