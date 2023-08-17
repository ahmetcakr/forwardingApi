using Core.Application.Dtos;

namespace Application.Features.FirmTypes.Queries.GetList;

public class GetListFirmTypeListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}