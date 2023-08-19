using Core.Application.Responses;

namespace Application.Features.Detentions.Commands.Delete;

public class DeletedDetentionResponse : IResponse
{
    public int Id { get; set; }
}