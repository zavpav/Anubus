
namespace ConsoleTest
{
    [Binding]
    public class MainSteps
    {
        #region Логин в систему. Создание приложения.
        /// <summary> Логин или перелогин в систему </summary>
		/// <exception cref="AssertionException"></exception>
		[StepDefinition(@"логинимся под '([^']+)'")]
        [StepDefinition(@"логинимся под ""([^""]+)""")]
        public void ApplicationLogining(string login)
        {
            //try
            //{
            //    login = Locator.Resolve<ITestExternalStepParameters>().ReplaceParameters(login);
            //}
            //// ReSharper disable once EmptyGeneralCatchClause
            //catch (Exception) { } // Давим ошибки. Тут могут быть, если это первый старт

            //ApplicationLoginingPasswordInternal(login, null);
        }

        /// <summary> Логин или перелогин в систему </summary>
        [StepDefinition(@"логинимся под '([^']+)' с паролем '([^']+)'")]
        [StepDefinition(@"логинимся под ""([^""]+)"" с паролем ""([^""]+)""")]
        public void ApplicationLoginingPassword(string login, string passwd)
        {
            //try
            //{
            //    login = Locator.Resolve<ITestExternalStepParameters>().ReplaceParameters(login);
            //    passwd = Locator.Resolve<ITestExternalStepParameters>().ReplaceParameters(passwd);
            //}
            //// ReSharper disable once EmptyGeneralCatchClause
            //catch (Exception) { } // Давим ошибки. Тут могут быть, если это первый старт

            //ApplicationLoginingPasswordInternal(login, passwd);
        }

        /// <summary> Логин или перелогин в систему </summary>
        [StepDefinition(@"логинимся под '([^']+)' с паролем '([^']+)' с датой '([^']+)'")]
        [StepDefinition(@"логинимся под ""([^""]+)"" с паролем ""([^""]+)"" с датой ""([^""]+)""")]
        public void ApplicationLoginingPasswordGlodate(string login, string passwd, string glodateStr)
        {
            //try
            //{
            //    login = Locator.Resolve<ITestExternalStepParameters>().ReplaceParameters(login);
            //    passwd = Locator.Resolve<ITestExternalStepParameters>().ReplaceParameters(passwd);
            //    glodateStr = Locator.Resolve<ITestExternalStepParameters>().ReplaceParameters(glodateStr);
            //}
            //// ReSharper disable once EmptyGeneralCatchClause
            //catch (Exception) { } // Давим ошибки. Тут могут быть, если это первый старт

            //ApplicationLoginingPasswordInternal(login, passwd, glodateStr);
        }

        /// <summary> Логин в систему с проверкой </summary>
        /// <exception cref="IgnoreException">Приложение запущено не под тем контекстом</exception>
        [StepDefinition("приложение запущено под '([^']+)'")]
        [StepDefinition(@"приложение запущено под ""([^""]+)""")]
        public void ApplicationStarted(string loginLevel)
        {
            //var mustLoginName = CreateApplicationStart(loginLevel, null, null);
            //var mainContext = Locator.Resolve<IMainContext>();
            //if (mainContext.UserLogin != mustLoginName)
            //    throw new IgnoreException(string.Format("Приложение запущено не под тем контекстом! {0} {1} != {2}", loginLevel, mustLoginName, mainContext.UserLogin));
        }
        #endregion

        [StepDefinition(@"проверяем рабочий год =(\d{4})")]
        public void CheckCurrentContextYear(int yearNum)
        {
            var currentYear = DateTime.Now.Year;
            if (yearNum != currentYear)
                throw new IgnoreException(string.Format("Год не соответствует ожидаемому {0} != {1}", currentYear, yearNum));

        }

        [StepDefinition("пересоздать временную папку")]
        public void RecreateTempDir()
        {
            //try
            //{
            //    var testContext = Locator.Resolve<ITestContext>();
            //    testContext.RecreateTempDir();
            //}
            //catch
            //{
            //    var testContext = new TestCore.Framework.TestContext();
            //    testContext.RecreateTempDir();
            //}
        }

        #region Тривиальные методы ОК/Проблема
        [StepDefinition("всё хорошо")]
        public void AllOk() { }

        [StepDefinition("ничего не делаем")]
        public void DoNothing() { }

        /// <summary> Выбрасывает IgnoreException </summary>
        /// <exception cref="IgnoreException">Игнорируем, потому что нам плохо.</exception>
        [StepDefinition("нам плохо")]
        public void StopIgnore()
        {
            throw new IgnoreException("Игнорируем, потому что нам плохо.");
        }

        [StepDefinition(@"Ждем-с '(.*)'")]
        [StepDefinition(@"Ждем-с ""([^""]+)""")]
        public void Waiting(int waitTime)
        {
            //TestHelper.Waiting(waitTime);
        }

        [StepDefinition(@"Ждем-с (.*) сек")]
        public void WaitingSec(int waitTime)
        {
            //TestHelper.DoEvents();
            //ProgramStarter.DoEventsWithLittleDelay();
            //TestHelper.Waiting(waitTime * 1000);
            //TestHelper.DoEvents();
        }
        #endregion
    }
}
