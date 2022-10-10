using TestConsoleTest.DomainInformation;

namespace TestConsoleTest;

/// <summary> Информация по домену </summary>
public interface ITestDomainDescription
{
    /// <summary> Русское наименование домена </summary>
    string RusName { get; }

    /// <summary> Доменных тип </summary>
    Type DomainType { get; }

    /// <summary> Ссылка на прокладку-репозитарий </summary>
    TestDomainInformation.IRepository Repository { get; set; }

    /// <summary> Создать доменный объект </summary>
    object CreateDomain();

    /// <summary> Url списка </summary>
    string? ClientListUrl { get; set; }

    /// <summary> Получить все свойства объекта </summary>
    IEnumerable<DomainPropertyInfo> AllPropertiesInfo();
    
    /// <summary> Получить описание свойства по русскому имени </summary>
    /// <param name="rusName">Русское имя</param>
    DomainPropertyInfo PropertyInfo(string rusName);
}
