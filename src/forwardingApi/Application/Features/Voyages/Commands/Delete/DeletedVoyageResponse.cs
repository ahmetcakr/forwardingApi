using Core.Application.Responses;

namespace Application.Features.Voyages.Commands.Delete;

public class DeletedVoyageResponse : IResponse
{
    public int Id { get; set; }
}