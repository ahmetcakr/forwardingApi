using Core.Application.Dtos;

namespace Application.Features.Ships.Queries.GetList;

public class GetListShipListItemDto : IDto
{
    public int Id { get; set; }
    public string ShipName { get; set; }
}