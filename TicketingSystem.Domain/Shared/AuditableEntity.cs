namespace TicketingSystem.Domain.Shared;

public abstract class AuditableEntity<TId> : Entity<TId>, IAuditableEntity
{
    public DateTime CreatedAt { get; protected set; }
    public Guid? CreatedBy { get; protected set; }

    public DateTime? UpdatedAt { get; protected set; }
    public Guid? UpdatedBy { get; protected set; }

    public DateTime? DeletedAt { get; protected set; }
    public Guid? DeletedBy { get; protected set; }

    public bool IsDeleted { get; protected set; }

    public void SetCreated(Guid userId)
    {
        CreatedAt = DateTime.UtcNow;
        CreatedBy = userId;
    }

    public void SetUpdated(Guid userId)
    {
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = userId;
    }

    public void SoftDelete(Guid userId)
    {
        if (IsDeleted) return;
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
        DeletedBy = userId;
    }

    public void UndoDelete()
    {
        IsDeleted = false;
        DeletedAt = null;
        DeletedBy = null;
    }
}
