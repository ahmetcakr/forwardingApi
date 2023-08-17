using Core.Application.Responses;

namespace Application.Features.FirmTypes.Commands.Delete;

public class DeletedFirmTypeResponse : IResponse
{
    public int Id { get; set; }
}