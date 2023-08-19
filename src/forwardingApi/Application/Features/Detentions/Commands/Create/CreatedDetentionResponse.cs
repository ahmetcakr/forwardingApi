using Core.Application.Responses;

namespace Application.Features.Detentions.Commands.Create;

public class CreatedDetentionResponse : IResponse
{
    public int Id { get; set; }
    public int? Day { get; set; }
    public int? Fee { get; set; }
}