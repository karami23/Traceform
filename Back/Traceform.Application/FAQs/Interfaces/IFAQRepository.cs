using Traceform.Domain.Entities;

namespace Traceform.Application.FAQs.Interfaces;

public interface IFAQRepository
{
    Task<IReadOnlyList<FAQ>> GetPublishedAsync(
        CancellationToken cancellationToken = default);
}