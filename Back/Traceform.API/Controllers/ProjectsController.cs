using Microsoft.AspNetCore.Mvc;
using Traceform.Application.Projects.Queries.GetProjects;

namespace Traceform.API.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly GetProjectsHandler _getProjectsHandler;

    public ProjectsController(
        GetProjectsHandler getProjectsHandler)
    {
        _getProjectsHandler = getProjectsHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken)
    {
        var result = await _getProjectsHandler.HandleAsync(
            new GetProjectsQuery(),
            cancellationToken);

        return Ok(result);
    }
}