using Core.Application.Responses;

namespace Application.Features.CustomerCommercialTypes.Queries.GetById;

public class GetByIdCustomerCommercialTypeResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CommercialTypeId { get; set; }
}