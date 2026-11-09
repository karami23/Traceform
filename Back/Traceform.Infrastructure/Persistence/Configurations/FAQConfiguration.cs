using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Traceform.Domain.Entities;

namespace Traceform.Infrastructure.Persistence.Configurations;

public class FAQConfiguration : IEntityTypeConfiguration<FAQ>
{
    public void Configure(EntityTypeBuilder<FAQ> builder)
    {
        builder.ToTable("FAQs");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Question)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Answer)
            .IsRequired();

        builder.Property(x => x.DisplayOrder)
            .IsRequired();

        builder.Property(x => x.IsPublished)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);
    }
}