using Core.Application.Responses;

namespace Application.Features.CustomerEBills.Commands.Create;

public class CreatedCustomerEBillResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int EBillId { get; set; }
}