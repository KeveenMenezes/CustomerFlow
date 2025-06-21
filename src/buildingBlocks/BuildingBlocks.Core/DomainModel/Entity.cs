namespace CustomerFlow.BuildingBlocks.Core.DomainModel;

public abstract class Entity<T>
    : IEntity<T>
{
    public T Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }

    protected Entity() { }

    public virtual IEntity<T> Create()
    {
        CreatedAt = DateTime.UtcNow;
        return this;
    }

    public void Update()
    {
        LastModified = DateTime.UtcNow;
    }
}
