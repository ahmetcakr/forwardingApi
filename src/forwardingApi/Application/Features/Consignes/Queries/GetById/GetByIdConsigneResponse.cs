using Core.Application.Responses;

namespace Application.Features.Consignes.Queries.GetById;

public class GetByIdConsigneResponse : IResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}