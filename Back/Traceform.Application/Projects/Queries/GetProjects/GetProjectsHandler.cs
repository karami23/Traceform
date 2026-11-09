using Traceform.Application.Projects.DTOs;
using Traceform.Application.Projects.Interfaces;

namespace Traceform.Application.Projects.Queries.GetProjects;

public class GetProjectsHandler
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectsHandler(
        IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<IReadOnlyList<ProjectDto>> HandleAsync(
        GetProjectsQuery query,
        CancellationToken cancellationToken = default)
    {
        var projects = await _projectRepository.GetPublishedAsync(
            cancellationToken);

        return projects
            .Select(project => new ProjectDto(
                project.Id,
                project.Title,
                project.Description,
                project.ImageUrl,
                project.Location))
            .ToList();
    }
}