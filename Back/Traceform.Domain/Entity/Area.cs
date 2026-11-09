using Traceform.Domain.Exceptions;

namespace Traceform.Domain.Entities;

public class Area : BaseEntity
{
    public string Name { get; private set; } = null!;

    public string Slug { get; private set; } = null!;

    public string ShortDescription { get; private set; } = null!;

    public string Description { get; private set; } = null!;

    public bool IsActive { get; private set; }

    public int DisplayOrder { get; private set; }

    private Area()
    {
    }

    private Area(
        string name,
        string slug,
        string shortDescription,
        string description,
        int displayOrder)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;

        Name = name;
        Slug = slug;
        ShortDescription = shortDescription;
        Description = description;
        IsActive = true;
        DisplayOrder = displayOrder;
    }

    public static Area Create(
        string name,
        string slug,
        string shortDescription,
        string description,
        int displayOrder)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException(
                $"{nameof(name)} is required.");

        if (string.IsNullOrWhiteSpace(slug))
            throw new DomainException(
                $"{nameof(slug)} is required.");

        if (string.IsNullOrWhiteSpace(shortDescription))
            throw new DomainException(
                $"{nameof(shortDescription)} is required.");

        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException(
                $"{nameof(description)} is required.");

        if (displayOrder < 1)
            throw new DomainException(
                $"{nameof(displayOrder)} must be greater than zero.");

        return new Area(
            name.Trim(),
            slug.Trim().ToLowerInvariant(),
            shortDescription.Trim(),
            description.Trim(),
            displayOrder);
    }

    public void Update(
        string name,
        string slug,
        string shortDescription,
        string description,
        int displayOrder)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException(
                $"{nameof(name)} is required.");

        if (string.IsNullOrWhiteSpace(slug))
            throw new DomainException(
                $"{nameof(slug)} is required.");

        if (string.IsNullOrWhiteSpace(shortDescription))
            throw new DomainException(
                $"{nameof(shortDescription)} is required.");

        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException(
                $"{nameof(description)} is required.");

        if (displayOrder < 1)
            throw new DomainException(
                $"{nameof(displayOrder)} must be greater than zero.");

        Name = name.Trim();
        Slug = slug.Trim().ToLowerInvariant();
        ShortDescription = shortDescription.Trim();
        Description = description.Trim();
        DisplayOrder = displayOrder;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Activate()
    {
        IsActive = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }
}