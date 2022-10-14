namespace Anubus.Api.Domain;



public interface IEntityTree : IEntityBase
{
    /// <summary> Родительский ИД для дерева </summary>
    [Description("Родитель")]
    public long? ParentId { get; set; }
}
