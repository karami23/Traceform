using Traceform.Application.Reviews.DTOs;
using Traceform.Application.Reviews.Interfaces;

namespace Traceform.Application.Reviews.Queries.GetReviews;

public class GetReviewsHandler
{
    private readonly IReviewRepository _reviewRepository;

    public GetReviewsHandler(
        IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<IReadOnlyList<ReviewDto>> HandleAsync(
        GetReviewsQuery query,
        CancellationToken cancellationToken = default)
    {
        var reviews = await _reviewRepository.GetPublishedAsync(
            cancellationToken);

        return reviews
            .Select(review => new ReviewDto(
                review.Id,
                review.CustomerName,
                review.Content,
                review.Rating,
                review.Status))
            .ToList();
    }
}