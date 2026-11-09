namespace Traceform.Application.Projects.DTOs;

public sealed record ProjectDto(
    Guid Id,
    string Title,
    string Description,
    string? ImageUrl,
    string Location);