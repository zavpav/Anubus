namespace Anubus.Api.Controllers;

/// <summary> Действие, которое можно совершить над объектом </summary>
public class ObjectAction
{
    public ObjectAction(string operation)
    {
        Operation = operation;
    }

    /// <summary> Имя операции </summary>
    public string Operation { get; set; }

    /// <summary> Куда пересылать </summary>
    public string? Endpoint { get; set; }

    /// <summary> Каким рисунком отображать </summary>
    public string? Glyph { get; set; }

    /// <summary> Какую подсказку писать </summary>
    public string? Tooltip { get; set; }
}
