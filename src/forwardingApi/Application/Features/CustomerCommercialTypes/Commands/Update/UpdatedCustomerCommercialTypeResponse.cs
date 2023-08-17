using Core.Application.Responses;

namespace Application.Features.CustomerCommercialTypes.Commands.Update;

public class UpdatedCustomerCommercialTypeResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CommercialTypeId { get; set; }
}