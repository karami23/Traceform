using Microsoft.EntityFrameworkCore;
using Traceform.Application.Projects.Interfaces;
using Traceform.Domain.Entities;
using Traceform.Infrastructure.Persistence.Context;

namespace Traceform.Infrastructure.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly TraceformDbContext _context;

    public ProjectRepository(TraceformDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Project>> GetPublishedAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Projects
            .AsNoTracking()
            .Where(x => x.IsPublished)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync(cancellationToken);
    }
}