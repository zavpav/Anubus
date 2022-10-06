namespace Anubus;

/// <summary> Атрибут для тестов </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class TestFieldDescriptionAttribute : Attribute
{
    /// <summary> Русское название поля </summary>
    public string RusFieldName { get; set; }

    /// <summary> Описание поля с точки зрения Тестов. </summary>
    /// <param name="rusTestFieldName">Имя поля, которое указывается в тестах</param>
    public TestFieldDescriptionAttribute(string rusTestFieldName)
    {
        this.RusFieldName = rusTestFieldName;
    }
}

