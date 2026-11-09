using Microsoft.EntityFrameworkCore;
using Traceform.Domain.Entities;

namespace Traceform.Infrastructure.Persistence.Context;

public class TraceformDbContext : DbContext
{
    public TraceformDbContext(
        DbContextOptions<TraceformDbContext> options)
        : base(options)
    {
    }

    public DbSet<Service> Services => Set<Service>();

    public DbSet<Area> Areas => Set<Area>();

    public DbSet<Review> Reviews => Set<Review>();

    public DbSet<FAQ> FAQs => Set<FAQ>();

    public DbSet<Project> Projects => Set<Project>();

    public DbSet<ContactRequest> ContactRequests => Set<ContactRequest>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(TraceformDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}