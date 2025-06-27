namespace CustomerFlow.BuildingBlocks.Core.DomainModel;

public interface IEntity<TId>
    : IEntity
{
    public TId Id { get; set; }
    public IEntity<TId> Create();
    public void Update();
}

public interface IEntity
{
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
}
