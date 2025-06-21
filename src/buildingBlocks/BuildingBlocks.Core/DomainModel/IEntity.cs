namespace CustomerFlow.BuildingBlocks.Core.DomainModel;

public interface IEntity<T>
    : IEntity
{
    public T Id { get; set; }
    public IEntity<T> Create();
    public void Update();
}

public interface IEntity
{
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
}
