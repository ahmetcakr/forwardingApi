using Core.Application.Responses;

namespace Application.Features.Sectors.Commands.Update;

public class UpdatedSectorResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}