using Microsoft.EntityFrameworkCore;
using Traceform.Application.FAQs.Interfaces;
using Traceform.Domain.Entities;
using Traceform.Infrastructure.Persistence.Context;

namespace Traceform.Infrastructure.Persistence.Repositories;

public class FAQRepository : IFAQRepository
{
    private readonly TraceformDbContext _context;

    public FAQRepository(TraceformDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<FAQ>> GetPublishedAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.FAQs
            .AsNoTracking()
            .Where(x => x.IsPublished)
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync(cancellationToken);
    }
}