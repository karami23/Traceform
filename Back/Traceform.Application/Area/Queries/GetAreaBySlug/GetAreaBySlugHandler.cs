using Traceform.Application.Areas.DTOs;
using Traceform.Application.Areas.Interfaces;

namespace Traceform.Application.Areas.Queries.GetAreaBySlug;

public class GetAreaBySlugHandler
{
    private readonly IAreaRepository _areaRepository;

    public GetAreaBySlugHandler(
        IAreaRepository areaRepository)
    {
        _areaRepository = areaRepository;
    }

    public async Task<AreaDto?> HandleAsync(
        GetAreaBySlugQuery query,
        CancellationToken cancellationToken = default)
    {
        var area = await _areaRepository.GetBySlugAsync(
            query.Slug,
            cancellationToken);

        if (area is null)
            return null;

        return new AreaDto(
            area.Id,
            area.Name,
            area.Slug,
            area.ShortDescription,
            area.Description,
            area.DisplayOrder);
    }
}