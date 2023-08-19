using Core.Application.Responses;

namespace Application.Features.Demurrages.Commands.Delete;

public class DeletedDemurrageResponse : IResponse
{
    public int Id { get; set; }
}