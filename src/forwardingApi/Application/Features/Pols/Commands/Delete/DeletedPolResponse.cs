using Core.Application.Responses;

namespace Application.Features.Pols.Commands.Delete;

public class DeletedPolResponse : IResponse
{
    public int Id { get; set; }
}