using Core.Application.Responses;

namespace Application.Features.Pols.Queries.GetById;

public class GetByIdPolResponse : IResponse
{
    public int Id { get; set; }
    public string PolName { get; set; }
}