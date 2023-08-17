using Core.Application.Responses;

namespace Application.Features.CustomerCommercialDetails.Commands.Update;

public class UpdatedCustomerCommercialDetailResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CommercialDetailId { get; set; }
}