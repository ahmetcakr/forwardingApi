using Core.Application.Responses;

namespace Application.Features.Sectors.Queries.GetById;

public class GetByIdSectorResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}