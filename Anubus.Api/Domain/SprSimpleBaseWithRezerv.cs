namespace Anubus.Api.Domain;

/// <summary> Базовый класс для справочника </summary>
public class SprSimpleBaseWithRezerv : SprSimpleBase
{
    /// <summary> Является резервом </summary>
    public bool IsRezerv { get; set; }
}
