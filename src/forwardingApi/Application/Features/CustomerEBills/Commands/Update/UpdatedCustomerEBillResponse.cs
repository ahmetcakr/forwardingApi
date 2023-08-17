using Core.Application.Responses;

namespace Application.Features.CustomerEBills.Commands.Update;

public class UpdatedCustomerEBillResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int EBillId { get; set; }
}