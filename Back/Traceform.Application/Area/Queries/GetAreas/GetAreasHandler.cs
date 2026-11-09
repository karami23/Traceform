using Traceform.Application.Areas.DTOs;
using Traceform.Application.Areas.Interfaces;

namespace Traceform.Application.Areas.Queries.GetAreas;

public class GetAreasHandler
{
    private readonly IAreaRepository _areaRepository;

    public GetAreasHandler(
        IAreaRepository areaRepository)
    {
        _areaRepository = areaRepository;
    }

    public async Task<IReadOnlyList<AreaDto>> HandleAsync(
        GetAreasQuery query,
        CancellationToken cancellationToken = default)
    {
        var areas = await _areaRepository.GetAllAsync(
            cancellationToken);

        return areas
            .Select(area => new AreaDto(
                area.Id,
                area.Name,
                area.Slug,
                area.ShortDescription,
                area.Description,
                area.DisplayOrder))
            .ToList();
    }
}