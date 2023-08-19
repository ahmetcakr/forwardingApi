using Core.Application.Responses;

namespace Application.Features.Ships.Queries.GetById;

public class GetByIdShipResponse : IResponse
{
    public int Id { get; set; }
    public string ShipName { get; set; }
}