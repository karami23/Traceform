using Traceform.Application.Services.DTOs;
using Traceform.Application.Services.Interfaces;

namespace Traceform.Application.Services.Queries.GetServices;

public class GetServicesHandler
{
    private readonly IServiceRepository _serviceRepository;

    public GetServicesHandler(
        IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<IReadOnlyList<ServiceDto>> HandleAsync(
        GetServicesQuery query,
        CancellationToken cancellationToken = default)
    {
        var services = await _serviceRepository.GetAllAsync(
            cancellationToken);

        return services
            .Select(service => new ServiceDto(
                service.Id,
                service.Title,
                service.Slug,
                service.ShortDescription,
                service.Description,
                service.ImageUrl,
                service.IsEmergency,
                service.DisplayOrder))
            .ToList();
    }
}