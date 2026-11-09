using Traceform.Domain.Exceptions;
namespace Traceform.Domain.Entities;

public class Service : BaseEntity
{
    public string Title { get; private set; } = null!;

    public string Slug { get; private set; } = null!;

    public string ShortDescription { get; private set; } = null!;

    public string Description { get; private set; } = null!;

    public string? ImageUrl { get; private set; }

    public bool IsEmergency { get; private set; }

    public bool IsActive { get; private set; }

    public int DisplayOrder { get; private set; }

    private Service()
    {
    }

    private Service(
        string title,
        string slug,
        string shortDescription,
        string description,
        string? imageUrl,
        bool isEmergency,
        int displayOrder)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;

        Title = title;
        Slug = slug;
        ShortDescription = shortDescription;
        Description = description;
        ImageUrl = imageUrl;
        IsEmergency = isEmergency;
        IsActive = true;
        DisplayOrder = displayOrder;
    }

    public static Service Create(
        string title,
        string slug,
        string shortDescription,
        string description,
        string? imageUrl,
        bool isEmergency,
        int displayOrder)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException(
                $"{nameof(title)} is required.");

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

        return new Service(
            title.Trim(),
            slug.Trim().ToLowerInvariant(),
            shortDescription.Trim(),
            description.Trim(),
            imageUrl?.Trim(),
            isEmergency,
            displayOrder);
    }

    public void Update(
        string title,
        string slug,
        string shortDescription,
        string description,
        string? imageUrl,
        bool isEmergency,
        int displayOrder)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException(
                $"{nameof(title)} is required.");

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

        Title = title.Trim();
        Slug = slug.Trim().ToLowerInvariant();
        ShortDescription = shortDescription.Trim();
        Description = description.Trim();
        ImageUrl = imageUrl?.Trim();
        IsEmergency = isEmergency;
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