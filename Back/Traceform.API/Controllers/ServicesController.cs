using Microsoft.AspNetCore.Mvc;
using Traceform.Application.Services.Queries.GetServiceBySlug;
using Traceform.Application.Services.Queries.GetServices;

namespace Traceform.API.Controllers;

[ApiController]
[Route("api/services")]
public class ServicesController : ControllerBase
{
    private readonly GetServicesHandler _getServicesHandler;
    private readonly GetServiceBySlugHandler _getServiceBySlugHandler;

    public ServicesController(
        GetServicesHandler getServicesHandler,
        GetServiceBySlugHandler getServiceBySlugHandler)
    {
        _getServicesHandler = getServicesHandler;
        _getServiceBySlugHandler = getServiceBySlugHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken)
    {
        var result = await _getServicesHandler.HandleAsync(
            new GetServicesQuery(),
            cancellationToken);

        return Ok(result);
    }

    [HttpGet("{slug}")]
    public async Task<IActionResult> GetBySlug(
        string slug,
        CancellationToken cancellationToken)
    {
        var result = await _getServiceBySlugHandler.HandleAsync(
            new GetServiceBySlugQuery(slug),
            cancellationToken);

        if (result is null)
            return NotFound();

        return Ok(result);
    }
}