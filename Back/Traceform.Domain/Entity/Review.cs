using Traceform.Domain.Enums;
using Traceform.Domain.Exceptions;

namespace Traceform.Domain.Entities;

public class Review : BaseEntity
{
    public string CustomerName { get; private set; } = null!;

    public string Content { get; private set; } = null!;

    public int Rating { get; private set; }

    public ReviewStatus Status { get; private set; }

    private Review()
    {
    }

    private Review(
        string customerName,
        string content,
        int rating)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;

        CustomerName = customerName;
        Content = content;
        Rating = rating;
        Status = ReviewStatus.Pending;
    }

    public static Review Create(
        string customerName,
        string content,
        int rating)
    {
        if (string.IsNullOrWhiteSpace(customerName))
            throw new DomainException(
                $"{nameof(customerName)} is required.");

        if (string.IsNullOrWhiteSpace(content))
            throw new DomainException(
                $"{nameof(content)} is required.");

        if (rating < 1 || rating > 5)
            throw new DomainException(
                $"{nameof(rating)} must be between 1 and 5.");

        return new Review(
            customerName.Trim(),
            content.Trim(),
            rating);
    }

    public void Update(
        string customerName,
        string content,
        int rating)
    {
        if (string.IsNullOrWhiteSpace(customerName))
            throw new DomainException(
                $"{nameof(customerName)} is required.");

        if (string.IsNullOrWhiteSpace(content))
            throw new DomainException(
                $"{nameof(content)} is required.");

        if (rating < 1 || rating > 5)
            throw new DomainException(
                $"{nameof(rating)} must be between 1 and 5.");

        CustomerName = customerName.Trim();
        Content = content.Trim();
        Rating = rating;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Publish()
    {
        Status = ReviewStatus.Published;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Reject()
    {
        Status = ReviewStatus.Rejected;
        UpdatedAt = DateTime.UtcNow;
    }
}