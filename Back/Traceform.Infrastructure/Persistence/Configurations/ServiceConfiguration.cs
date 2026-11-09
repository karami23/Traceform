using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Traceform.Domain.Entities;

namespace Traceform.Infrastructure.Persistence.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable("Services");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Slug)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasIndex(x => x.Slug)
            .IsUnique();

        builder.Property(x => x.ShortDescription)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Description)
            .IsRequired();

        builder.Property(x => x.ImageUrl)
            .HasMaxLength(1000);

        builder.Property(x => x.IsEmergency)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.Property(x => x.DisplayOrder)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);
    }
}