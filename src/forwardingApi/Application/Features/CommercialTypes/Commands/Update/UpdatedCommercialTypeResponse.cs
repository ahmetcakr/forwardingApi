using Core.Application.Responses;

namespace Application.Features.CommercialTypes.Commands.Update;

public class UpdatedCommercialTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}