namespace TicketingSystem.Domain.Interfaces;

public interface IUser
{
    Guid Id { get; }
    string FullName { get; }
    string Email { get; }
}
