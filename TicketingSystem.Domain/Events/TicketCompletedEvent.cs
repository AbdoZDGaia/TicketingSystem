namespace TicketingSystem.Domain.Events;

public record TicketCompletedEvent(Guid TicketId, DateTime CompletedAt) : IDomainEvent;
