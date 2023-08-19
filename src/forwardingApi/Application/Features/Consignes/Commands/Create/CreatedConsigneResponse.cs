using Core.Application.Responses;

namespace Application.Features.Consignes.Commands.Create;

public class CreatedConsigneResponse : IResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}