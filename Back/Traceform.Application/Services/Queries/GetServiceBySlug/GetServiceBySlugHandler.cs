using Traceform.Application.Services.DTOs;
using Traceform.Application.Services.Interfaces;

namespace Traceform.Application.Services.Queries.GetServiceBySlug;

public class GetServiceBySlugHandler
{
    private readonly IServiceRepository _serviceRepository;

    public GetServiceBySlugHandler(
        IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<ServiceDto?> HandleAsync(
        GetServiceBySlugQuery query,
        CancellationToken cancellationToken = default)
    {
        var service = await _serviceRepository.GetBySlugAsync(
            query.Slug,
            cancellationToken);

        if (service is null)
            return null;

        return new ServiceDto(
            service.Id,
            service.Title,
            service.Slug,
            service.ShortDescription,
            service.Description,
            service.ImageUrl,
            service.IsEmergency,
            service.DisplayOrder);
    }
}