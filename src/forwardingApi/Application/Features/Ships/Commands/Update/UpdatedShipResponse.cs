using Core.Application.Responses;

namespace Application.Features.Ships.Commands.Update;

public class UpdatedShipResponse : IResponse
{
    public int Id { get; set; }
    public string ShipName { get; set; }
}