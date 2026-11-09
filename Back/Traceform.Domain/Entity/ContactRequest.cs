using System.Text.RegularExpressions;
using Traceform.Domain.Exceptions;

namespace Traceform.Domain.Entities;

public class ContactRequest : BaseEntity
{
    public string Name { get; private set; } = null!;

    public string Email { get; private set; } = null!;

    public string Phone { get; private set; } = null!;

    public string? Message { get; private set; }

    private ContactRequest()
    {
    }

    private ContactRequest(
        string name,
        string email,
        string phone,
        string? message)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;

        Name = name;
        Email = email;
        Phone = phone;
        Message = message;
    }

    public static ContactRequest Create(
        string name,
        string email,
        string phone,
        string? message)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException(
                $"{nameof(name)} is required.");

        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException(
                $"{nameof(email)} is required.");
        if (!Regex.IsMatch(
        email.Trim(),
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            throw new DomainException(
                $"{nameof(email)} has an invalid format.");
        }

        if (string.IsNullOrWhiteSpace(phone))
            throw new DomainException(
                $"{nameof(phone)} is required.");

        return new ContactRequest(
            name.Trim(),
            email.Trim().ToLowerInvariant(),
            phone.Trim(),
            message?.Trim());
    }
}