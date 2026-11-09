using Microsoft.EntityFrameworkCore;
using Traceform.Application.Services.Interfaces;
using Traceform.Domain.Entities;
using Traceform.Infrastructure.Persistence.Context;

namespace Traceform.Infrastructure.Persistence.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly TraceformDbContext _context;

    public ServiceRepository(TraceformDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Service>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Services
            .AsNoTracking()
            .Where(x => x.IsActive)
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync(cancellationToken);
    }

    public async Task<Service?> GetBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default)
    {
        return await _context.Services
            .AsNoTracking()
            .FirstOrDefaultAsync(
                x => x.Slug == slug && x.IsActive,
                cancellationToken);
    }
}