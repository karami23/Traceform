using Microsoft.AspNetCore.Mvc;
using Traceform.Application.FAQs.Queries.GetFAQs;

namespace Traceform.API.Controllers;

[ApiController]
[Route("api/faqs")]
public class FAQsController : ControllerBase
{
    private readonly GetFAQsHandler _getFAQsHandler;

    public FAQsController(
        GetFAQsHandler getFAQsHandler)
    {
        _getFAQsHandler = getFAQsHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken)
    {
        var result = await _getFAQsHandler.HandleAsync(
            new GetFAQsQuery(),
            cancellationToken);

        return Ok(result);
    }
}