using Core.Application.Responses;

namespace Application.Features.Voyages.Queries.GetById;

public class GetByIdVoyageResponse : IResponse
{
    public int Id { get; set; }
    public string VoyageName { get; set; }
}