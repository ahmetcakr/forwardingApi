using Core.Application.Responses;

namespace Application.Features.CustomerCommercialDetails.Commands.Create;

public class CreatedCustomerCommercialDetailResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CommercialDetailId { get; set; }
}