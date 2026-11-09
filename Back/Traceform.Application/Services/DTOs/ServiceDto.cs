namespace Traceform.Application.Services.DTOs;

public sealed record ServiceDto(
    Guid Id,
    string Title,
    string Slug,
    string ShortDescription,
    string Description,
    string? ImageUrl,
    bool IsEmergency,
    int DisplayOrder);