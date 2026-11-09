using Traceform.Domain.Entities;

namespace Traceform.Application.Projects.Interfaces;

public interface IProjectRepository
{
    Task<IReadOnlyList<Project>> GetPublishedAsync(
        CancellationToken cancellationToken = default);
}