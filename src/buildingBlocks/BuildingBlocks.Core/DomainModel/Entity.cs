namespace CustomerFlow.BuildingBlocks.Core.DomainModel;

public abstract class Entity<TId, TPublicId>
    : Entity<TId>
    where TId : new()
    where TPublicId : new()
{
    public TPublicId PublicId { get; set; } = new TPublicId();
}

public abstract class Entity<T>
    : IEntity<T>
    where T : new()
{
    public T Id { get; set; } = new T();
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
