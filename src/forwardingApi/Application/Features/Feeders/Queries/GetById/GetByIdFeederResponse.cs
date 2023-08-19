using Core.Application.Responses;

namespace Application.Features.Feeders.Queries.GetById;

public class GetByIdFeederResponse : IResponse
{
    public int Id { get; set; }
    public string FeederName { get; set; }
}