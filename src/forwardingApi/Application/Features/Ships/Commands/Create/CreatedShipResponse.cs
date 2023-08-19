using Core.Application.Responses;

namespace Application.Features.Ships.Commands.Create;

public class CreatedShipResponse : IResponse
{
    public int Id { get; set; }
    public string ShipName { get; set; }
}