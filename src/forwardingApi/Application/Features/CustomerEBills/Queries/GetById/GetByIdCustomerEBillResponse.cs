using Core.Application.Responses;

namespace Application.Features.CustomerEBills.Queries.GetById;

public class GetByIdCustomerEBillResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int EBillId { get; set; }
}