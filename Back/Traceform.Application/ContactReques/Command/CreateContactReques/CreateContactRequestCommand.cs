namespace Traceform.Application.ContactRequests.Commands.CreateContactRequest;

public sealed record CreateContactRequestCommand(
    string Name,
    string Email,
    string Phone,
    string? Message);