using Core.Application.Responses;

namespace Application.Features.CustomerCommercialTypes.Commands.Create;

public class CreatedCustomerCommercialTypeResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CommercialTypeId { get; set; }
}