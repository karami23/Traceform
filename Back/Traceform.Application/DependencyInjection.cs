using Traceform.Application.Areas.Queries.GetAreaBySlug;
using Microsoft.Extensions.DependencyInjection;
using Traceform.Application.Areas.Queries.GetAreas;
using Traceform.Application.ContactRequests.Commands.CreateContactRequest;
using Traceform.Application.FAQs.Queries.GetFAQs;
using Traceform.Application.Projects.Queries.GetProjects;
using Traceform.Application.Reviews.Queries.GetReviews;
using Traceform.Application.Services.Queries.GetServiceBySlug;
using Traceform.Application.Services.Queries.GetServices;

namespace Traceform.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<GetServicesHandler>();
        services.AddScoped<GetServiceBySlugHandler>();

        services.AddScoped<GetAreasHandler>();
        services.AddScoped<GetAreaBySlugHandler>();

        services.AddScoped<GetReviewsHandler>();

        services.AddScoped<GetFAQsHandler>();

        services.AddScoped<GetProjectsHandler>();

        services.AddScoped<CreateContactRequestHandler>();

        return services;
    }
}