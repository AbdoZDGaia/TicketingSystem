using TicketingSystem.Domain.Enums;
using TicketingSystem.Domain.Events;
using TicketingSystem.Domain.Shared;

namespace TicketingSystem.Domain.Entities;

public class Ticket : AggregateRoot<Guid>, IAuditableEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public TicketStatus Status { get; private set; }
    public Guid? AssignedToUserId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }

    public List<TicketComment> Comments { get; private set; } = new();

    protected Ticket() { }

    public Ticket(string title, string description)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Status = TicketStatus.New;
        CreatedAt = DateTime.UtcNow;
    }

    public void AssignTo(Guid userId)
    {
        if (Status == TicketStatus.Closed)
            throw new InvalidOperationException("Cannot assign a closed ticket.");

        AssignedToUserId = userId;
        Status = TicketStatus.Assigned;
    }

    public void MarkCompleted()
    {
        if (Status != TicketStatus.Assigned)
            throw new InvalidOperationException("Only assigned tickets can be completed.");

        Status = TicketStatus.Completed;
        CompletedAt = DateTime.UtcNow;

        AddDomainEvent(new TicketCompletedEvent(Id, CompletedAt.Value));
    }

    public void AddComment(string text, Guid userId)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("Comment cannot be empty.");

        Comments.Add(new TicketComment(text, userId));
    }
}
