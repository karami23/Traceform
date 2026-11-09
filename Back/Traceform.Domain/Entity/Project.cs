using Traceform.Domain.Exceptions;

namespace Traceform.Domain.Entities;

public class Project : BaseEntity
{
    public string Title { get; private set; } = null!;

    public string Description { get; private set; } = null!;

    public string? ImageUrl { get; private set; }

    public string Location { get; private set; } = null!;

    public bool IsPublished { get; private set; }

    private Project()
    {
    }

    private Project(
        string title,
        string description,
        string? imageUrl,
        string location)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;

        Title = title;
        Description = description;
        ImageUrl = imageUrl;
        Location = location;
        IsPublished = true;
    }

    public static Project Create(
        string title,
        string description,
        string? imageUrl,
        string location)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException(
                $"{nameof(title)} is required.");

        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException(
                $"{nameof(description)} is required.");

        if (string.IsNullOrWhiteSpace(location))
            throw new DomainException(
                $"{nameof(location)} is required.");

        return new Project(
            title.Trim(),
            description.Trim(),
            imageUrl?.Trim(),
            location.Trim());
    }

    public void Update(
        string title,
        string description,
        string? imageUrl,
        string location)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException(
                $"{nameof(title)} is required.");

        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException(
                $"{nameof(description)} is required.");

        if (string.IsNullOrWhiteSpace(location))
            throw new DomainException(
                $"{nameof(location)} is required.");

        Title = title.Trim();
        Description = description.Trim();
        ImageUrl = imageUrl?.Trim();
        Location = location.Trim();
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