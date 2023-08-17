using Core.Application.Responses;

namespace Application.Features.Sectors.Commands.Create;

public class CreatedSectorResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}