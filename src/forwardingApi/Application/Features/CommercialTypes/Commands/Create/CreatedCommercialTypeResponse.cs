using Core.Application.Responses;

namespace Application.Features.CommercialTypes.Commands.Create;

public class CreatedCommercialTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}