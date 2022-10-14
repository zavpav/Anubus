namespace Anubus.Api.Domain;

public interface IEntityBase
{
    /// <summary> ИД </summary>
    [Description("ИД")]
    public long Id { get; set; }
}
