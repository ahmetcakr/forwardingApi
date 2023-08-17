using Core.Application.Responses;

namespace Application.Features.Sectors.Commands.Delete;

public class DeletedSectorResponse : IResponse
{
    public int Id { get; set; }
}