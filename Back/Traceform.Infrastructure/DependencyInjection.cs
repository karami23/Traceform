using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Traceform.Application.Areas.Interfaces;
using Traceform.Application.ContactRequests.Interfaces;
using Traceform.Application.FAQs.Interfaces;
using Traceform.Application.Projects.Interfaces;
using Traceform.Application.Reviews.Interfaces;
using Traceform.Application.Services.Interfaces;
using Traceform.Infrastructure.Persistence.Context;
using Traceform.Infrastructure.Persistence.Repositories;

namespace Traceform.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<TraceformDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IAreaRepository, AreaRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<IFAQRepository, FAQRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IContactRequestRepository, ContactRequestRepository>();

        return services;
    }
}