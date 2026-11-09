using Traceform.Domain.Entities;

namespace Traceform.Application.Areas.Interfaces;

public interface IAreaRepository
{
    Task<IReadOnlyList<Area>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<Area?> GetBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default);
}