namespace Traceform.Application.Areas.DTOs;

public sealed record AreaDto(
    Guid Id,
    string Name,
    string Slug,
    string ShortDescription,
    string Description,
    int DisplayOrder);