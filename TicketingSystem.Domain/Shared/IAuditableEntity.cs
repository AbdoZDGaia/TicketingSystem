namespace TicketingSystem.Domain.Shared;

public interface IAuditableEntity
{
    DateTime CreatedAt { get; }
    Guid? CreatedBy { get; }

    DateTime? UpdatedAt { get; }
    Guid? UpdatedBy { get; }

    DateTime? DeletedAt { get; }
    Guid? DeletedBy { get; }
    bool IsDeleted { get; }
}
