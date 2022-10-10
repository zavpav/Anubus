using Anubus.Services.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Protractor;
using TestConsoleTest;

namespace Test.AnubusTest.TestOfTest
{
    [TestFixture]
    public class TestTestTest
    {
        [SetUp]
        public void Steup()
        {
            LoggerConfiguration.ConfigureWebApiPart();
        }

        [Test]
        public void Ex()
        {
            Console.WriteLine("aaaa");
        }

        [Test]
        public void Exec()
        {
            var driver = new ChromeDriver(@"C:\Users\Papa\.nuget\packages\selenium.webdriver.chromedriver\105.0.5195.5200\driver\win32");
            try
            {
                var manageDriver = driver.Manage();

                manageDriver.Window.Maximize();
                manageDriver.Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);

                using var ngDriver = new NgWebDriver(driver);

                ngDriver.Url = "http://localhost:4200/login-form";
                ngDriver.FindInputElementBy(By.Id("itmTest")).SendKeys("123455");
                ngDriver.FindInputElementBy(By.Id("itmDate")).SendKeys("19.05.2022");
                
                try
                {
                    ngDriver.FindInputElementBy(By.TagName("input"));
                }
                catch (Exception ex)
                {
                    Log.Default.Error(ex, "Ошибка поиска input");
                }

                try
                {
                    ngDriver.FindInputElementBy(By.Id("asdfasdfdasf"));
                }
                catch (Exception ex)
                {
                    Log.Default.Error(ex, "Ошибка поиска по кривому id");
                }


                ngDriver.Url = "http://localhost:4200/spr/grbs/entity/123";
            
                try
                {
                    var el = ngDriver.FindInputElementByCaption("Полное наименование");
                    el.SendKeys("Тарампампам");
                }
                catch (Exception ex)
                {
                    Log.Default.Error(ex, "Ошибка поиска по кривому id");
                }

                try
                {
                    var el = ngDriver.FindButtonByCaption("ЖМИ!");
                    el.Click();
                }
                catch (Exception ex)
                {
                    Log.Default.Error(ex, "Ошибка поиска Кнопки");
                }

                try
                {
                    var el = ngDriver.FindButtonByCaption("ДВА");
                    el.Click();
                }
                catch (Exception ex)
                {
                    Log.Default.Error(ex, "Ошибка поиска Кнопки");
                }

                Thread.Sleep(2000);
            }
            finally
            {
                driver.Quit();
            }
        }

    }
}
