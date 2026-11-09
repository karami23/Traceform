using Microsoft.AspNetCore.Mvc;
using Traceform.Application.Reviews.Queries.GetReviews;

namespace Traceform.API.Controllers;

[ApiController]
[Route("api/reviews")]
public class ReviewsController : ControllerBase
{
    private readonly GetReviewsHandler _getReviewsHandler;

    public ReviewsController(
        GetReviewsHandler getReviewsHandler)
    {
        _getReviewsHandler = getReviewsHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken)
    {
        var result = await _getReviewsHandler.HandleAsync(
            new GetReviewsQuery(),
            cancellationToken);

        return Ok(result);
    }
}