using TestConsoleTest.DomainInformation;

namespace TestConsoleTest;

/// <summary> Описание домена </summary>
public interface ITestDomainInformation
{
    /// <summary> Получить информацию о домене по имени </summary>
    /// <param name="rusName">Русское имя</param>
    /// <returns>Информация по домену</returns>
    /// <exception cref="IgnoreException">Стоп тестов</exception>
    ITestDomainDescription GetDomainDesc(string rusName);
}
