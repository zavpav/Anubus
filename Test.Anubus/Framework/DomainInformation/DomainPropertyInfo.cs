using System.Reflection;

namespace TestConsoleTest.DomainInformation;

#pragma warning disable CS8618 // Пока не придумал что с этим делать. Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable. 

/// <summary> Вспомогательный класс описания информации поля </summary>
public class DomainPropertyInfo
{
    /// <summary> Русское наименование поля, если есть TestFieldDescriptionAttribute и т.д.</summary>
    /// <remarks> Если поле не имеет "описания", то пишется "@PropertyName"</remarks>
    public string Name { get; internal set; }

    /// <summary> Реальный PropertyInfo </summary>
    public PropertyInfo PropertyInfo { get; internal set; }

    /// <summary> Getter данных </summary>
    public Func<object, object> Getter { get; internal set; }

    /// <summary> Сеттер данных по строковому значению </summary>
    /// <remarks> Если свойство только для чтения, сюда запихивается stub с логированием</remarks>
    public Action<object, string> Setter { get; internal set; }

    public DomainPropertyInfo Clone()
    {
        return new DomainPropertyInfo
        {
            Name = this.Name,
            PropertyInfo = this.PropertyInfo,
            Getter = this.Getter,
            Setter = this.Setter,
        };
    }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
