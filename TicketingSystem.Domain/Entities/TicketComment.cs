using TicketingSystem.Domain.Shared;

namespace TicketingSystem.Domain.Entities;

public class TicketComment : AuditableEntity<Guid>
{
    public Guid UserId { get; private set; }
    public string Text { get; private set; }
    public DateTime CreatedAt { get; private set; }

    protected TicketComment() { }

    public TicketComment(string text, Guid userId)
    {
        Id = Guid.NewGuid();
        Text = text;
        UserId = userId;
        CreatedAt = DateTime.UtcNow;
    }
}
