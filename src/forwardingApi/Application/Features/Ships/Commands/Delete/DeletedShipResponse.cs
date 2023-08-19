using Core.Application.Responses;

namespace Application.Features.Ships.Commands.Delete;

public class DeletedShipResponse : IResponse
{
    public int Id { get; set; }
}