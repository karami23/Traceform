using Traceform.Domain.Exceptions;

namespace Traceform.Domain.Entities;

public class FAQ : BaseEntity
{
    public string Question { get; private set; } = null!;

    public string Answer { get; private set; } = null!;

    public int DisplayOrder { get; private set; }

    public bool IsPublished { get; private set; }

    private FAQ()
    {
    }

    private FAQ(
        string question,
        string answer,
        int displayOrder)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;

        Question = question;
        Answer = answer;
        DisplayOrder = displayOrder;
        IsPublished = true;
    }

    public static FAQ Create(
        string question,
        string answer,
        int displayOrder)
    {
        if (string.IsNullOrWhiteSpace(question))
            throw new DomainException(
                $"{nameof(question)} is required.");

        if (string.IsNullOrWhiteSpace(answer))
            throw new DomainException(
                $"{nameof(answer)} is required.");

        if (displayOrder < 1)
            throw new DomainException(
                $"{nameof(displayOrder)} must be greater than zero.");

        return new FAQ(
            question.Trim(),
            answer.Trim(),
            displayOrder);
    }

    public void Update(
        string question,
        string answer,
        int displayOrder)
    {
        if (string.IsNullOrWhiteSpace(question))
            throw new DomainException(
                $"{nameof(question)} is required.");

        if (string.IsNullOrWhiteSpace(answer))
            throw new DomainException(
                $"{nameof(answer)} is required.");

        if (displayOrder < 1)
            throw new DomainException(
                $"{nameof(displayOrder)} must be greater than zero.");

        Question = question.Trim();
        Answer = answer.Trim();
        DisplayOrder = displayOrder;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Publish()
    {
        IsPublished = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Unpublish()
    {
        IsPublished = false;
        UpdatedAt = DateTime.UtcNow;
    }
}