using Core.Application.Responses;

namespace Application.Features.FirmTypes.Queries.GetById;

public class GetByIdFirmTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}