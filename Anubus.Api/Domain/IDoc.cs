namespace Anubus.Api.Domain.Docs;

public interface IDoc
{
    /// <summary> Номер документа </summary>
    string DocNum { get; }

    /// <summary> Дата подписания/дата учёта документа/самая главная дата документа </summary>
    DateTime? ApproveDt { get; }

    /// <summary> Дата создания документа </summary>
    DateTime CreateDt { get; }

    /// <summary> Статус документа </summary>
    string DocStatus { get; }

    /// <summary> Русскоязычное название статуса документа </summary>
    string DocStatusName { get; }

    /// <summary> Комментарий к документу </summary>
    string Descr { get; }

    /// <summary>
    /// ИД пользователя, который считается "ответственным" за документ.
    /// (может меняться, например, при утверждении документа)
    /// </summary>
    long UserSid { get; }
}
