using Core.Application.Responses;

namespace Application.Features.CustomerCommercialDetails.Queries.GetById;

public class GetByIdCustomerCommercialDetailResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CommercialDetailId { get; set; }
}