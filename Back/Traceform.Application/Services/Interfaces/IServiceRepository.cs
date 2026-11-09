using Traceform.Domain.Entities;

namespace Traceform.Application.Services.Interfaces;

public interface IServiceRepository
{
    Task<IReadOnlyList<Service>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<Service?> GetBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default);
}