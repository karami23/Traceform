using Microsoft.AspNetCore.Mvc;
using Traceform.Application.Areas.Queries.GetAreaBySlug;
using Traceform.Application.Areas.Queries.GetAreas;

namespace Traceform.API.Controllers;

[ApiController]
[Route("api/areas")]
public class AreasController : ControllerBase
{
    private readonly GetAreasHandler _getAreasHandler;
    private readonly GetAreaBySlugHandler _getAreaBySlugHandler;

    public AreasController(
        GetAreasHandler getAreasHandler,
        GetAreaBySlugHandler getAreaBySlugHandler)
    {
        _getAreasHandler = getAreasHandler;
        _getAreaBySlugHandler = getAreaBySlugHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken)
    {
        var result = await _getAreasHandler.HandleAsync(
            new GetAreasQuery(),
            cancellationToken);

        return Ok(result);
    }

    [HttpGet("{slug}")]
    public async Task<IActionResult> GetBySlug(
        string slug,
        CancellationToken cancellationToken)
    {
        var result = await _getAreaBySlugHandler.HandleAsync(
            new GetAreaBySlugQuery(slug),
            cancellationToken);

        if (result is null)
            return NotFound();

        return Ok(result);
    }
}