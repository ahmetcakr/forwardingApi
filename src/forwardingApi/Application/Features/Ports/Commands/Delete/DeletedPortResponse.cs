using Core.Application.Responses;

namespace Application.Features.Ports.Commands.Delete;

public class DeletedPortResponse : IResponse
{
    public int Id { get; set; }
}