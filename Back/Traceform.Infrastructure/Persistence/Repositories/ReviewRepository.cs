using Microsoft.EntityFrameworkCore;
using Traceform.Application.Reviews.Interfaces;
using Traceform.Domain.Entities;
using Traceform.Domain.Enums;
using Traceform.Infrastructure.Persistence.Context;

namespace Traceform.Infrastructure.Persistence.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly TraceformDbContext _context;

    public ReviewRepository(TraceformDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Review>> GetPublishedAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Reviews
            .AsNoTracking()
            .Where(x => x.Status == ReviewStatus.Published)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync(cancellationToken);
    }
}