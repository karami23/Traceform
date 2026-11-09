using Microsoft.AspNetCore.Mvc;
using Traceform.Application.ContactRequests.Commands.CreateContactRequest;

namespace Traceform.API.Controllers;

[ApiController]
[Route("api/contact-requests")]
public class ContactRequestsController : ControllerBase
{
    private readonly CreateContactRequestHandler _handler;

    public ContactRequestsController(
        CreateContactRequestHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateContactRequestCommand command,
        CancellationToken cancellationToken)
    {
        var id = await _handler.HandleAsync(
            command,
            cancellationToken);

        return CreatedAtAction(
            nameof(Create),
            new { id },
            new { id });
    }
}