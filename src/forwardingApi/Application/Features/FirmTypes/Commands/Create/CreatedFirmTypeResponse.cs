using Core.Application.Responses;

namespace Application.Features.FirmTypes.Commands.Create;

public class CreatedFirmTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}