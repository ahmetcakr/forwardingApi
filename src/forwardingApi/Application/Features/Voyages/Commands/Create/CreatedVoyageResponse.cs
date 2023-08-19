using Core.Application.Responses;

namespace Application.Features.Voyages.Commands.Create;

public class CreatedVoyageResponse : IResponse
{
    public int Id { get; set; }
    public string VoyageName { get; set; }
}