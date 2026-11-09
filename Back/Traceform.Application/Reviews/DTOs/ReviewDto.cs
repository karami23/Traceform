using Traceform.Domain.Enums;

namespace Traceform.Application.Reviews.DTOs;

public sealed record ReviewDto(
    Guid Id,
    string CustomerName,
    string Content,
    int Rating,
    ReviewStatus Status);