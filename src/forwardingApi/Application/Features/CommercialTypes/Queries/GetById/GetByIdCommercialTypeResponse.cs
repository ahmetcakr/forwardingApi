using Core.Application.Responses;

namespace Application.Features.CommercialTypes.Queries.GetById;

public class GetByIdCommercialTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}