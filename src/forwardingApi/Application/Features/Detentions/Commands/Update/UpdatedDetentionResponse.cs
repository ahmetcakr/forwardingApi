using Core.Application.Responses;

namespace Application.Features.Detentions.Commands.Update;

public class UpdatedDetentionResponse : IResponse
{
    public int Id { get; set; }
    public int? Day { get; set; }
    public int? Fee { get; set; }
}