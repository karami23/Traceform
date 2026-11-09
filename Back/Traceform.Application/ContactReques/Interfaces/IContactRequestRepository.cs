using Traceform.Domain.Entities;

namespace Traceform.Application.ContactRequests.Interfaces;

public interface IContactRequestRepository
{
    Task AddAsync(
        ContactRequest contactRequest,
        CancellationToken cancellationToken = default);
}