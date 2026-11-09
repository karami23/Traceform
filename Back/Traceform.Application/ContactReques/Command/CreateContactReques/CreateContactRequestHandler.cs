using Traceform.Application.ContactRequests.Interfaces;
using Traceform.Domain.Entities;

namespace Traceform.Application.ContactRequests.Commands.CreateContactRequest;

public class CreateContactRequestHandler
{
    private readonly IContactRequestRepository _contactRequestRepository;

    public CreateContactRequestHandler(
        IContactRequestRepository contactRequestRepository)
    {
        _contactRequestRepository = contactRequestRepository;
    }

    public async Task<Guid> HandleAsync(
        CreateContactRequestCommand command,
        CancellationToken cancellationToken = default)
    {
        var contactRequest = ContactRequest.Create(
            command.Name,
            command.Email,
            command.Phone,
            command.Message);

        await _contactRequestRepository.AddAsync(
            contactRequest,
            cancellationToken);

        return contactRequest.Id;
    }
}