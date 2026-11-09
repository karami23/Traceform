using Traceform.Application.ContactRequests.Interfaces;
using Traceform.Domain.Entities;
using Traceform.Infrastructure.Persistence.Context;

namespace Traceform.Infrastructure.Persistence.Repositories;

public class ContactRequestRepository : IContactRequestRepository
{
    private readonly TraceformDbContext _context;

    public ContactRequestRepository(TraceformDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        ContactRequest contactRequest,
        CancellationToken cancellationToken = default)
    {
        await _context.ContactRequests.AddAsync(
            contactRequest,
            cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }
}