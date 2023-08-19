using Core.Application.Responses;

namespace Application.Features.Pols.Commands.Create;

public class CreatedPolResponse : IResponse
{
    public int Id { get; set; }
    public string PolName { get; set; }
}