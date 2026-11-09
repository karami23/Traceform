using Microsoft.EntityFrameworkCore;
using Traceform.Application.Areas.Interfaces;
using Traceform.Domain.Entities;
using Traceform.Infrastructure.Persistence.Context;

namespace Traceform.Infrastructure.Persistence.Repositories;

public class AreaRepository : IAreaRepository
{
    private readonly TraceformDbContext _context;

    public AreaRepository(TraceformDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Area>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Areas
            .AsNoTracking()
            .Where(x => x.IsActive)
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync(cancellationToken);
    }

    public async Task<Area?> GetBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default)
    {
        return await _context.Areas
            .AsNoTracking()
            .FirstOrDefaultAsync(
                x => x.Slug == slug && x.IsActive,
                cancellationToken);
    }
}