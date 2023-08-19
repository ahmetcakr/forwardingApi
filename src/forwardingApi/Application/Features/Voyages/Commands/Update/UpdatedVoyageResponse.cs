using Core.Application.Responses;

namespace Application.Features.Voyages.Commands.Update;

public class UpdatedVoyageResponse : IResponse
{
    public int Id { get; set; }
    public string VoyageName { get; set; }
}