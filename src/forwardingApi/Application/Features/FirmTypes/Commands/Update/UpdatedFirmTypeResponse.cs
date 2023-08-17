using Core.Application.Responses;

namespace Application.Features.FirmTypes.Commands.Update;

public class UpdatedFirmTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}