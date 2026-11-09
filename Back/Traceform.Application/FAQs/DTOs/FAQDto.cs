namespace Traceform.Application.FAQs.DTOs;

public sealed record FAQDto(
    Guid Id,
    string Question,
    string Answer,
    int DisplayOrder);