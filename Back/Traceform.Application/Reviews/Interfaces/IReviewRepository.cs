using Traceform.Domain.Entities;

namespace Traceform.Application.Reviews.Interfaces;

public interface IReviewRepository
{
    Task<IReadOnlyList<Review>> GetPublishedAsync(
        CancellationToken cancellationToken = default);
}