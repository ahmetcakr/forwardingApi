using Core.Application.Responses;

namespace Application.Features.Feeders.Commands.Delete;

public class DeletedFeederResponse : IResponse
{
    public int Id { get; set; }
}