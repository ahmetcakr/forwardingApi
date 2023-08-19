using Core.Application.Responses;

namespace Application.Features.Detentions.Queries.GetById;

public class GetByIdDetentionResponse : IResponse
{
    public int Id { get; set; }
    public int? Day { get; set; }
    public int? Fee { get; set; }
}