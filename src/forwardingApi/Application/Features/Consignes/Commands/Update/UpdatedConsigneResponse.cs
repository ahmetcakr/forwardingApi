using Core.Application.Responses;

namespace Application.Features.Consignes.Commands.Update;

public class UpdatedConsigneResponse : IResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}