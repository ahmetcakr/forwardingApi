using Core.Application.Responses;

namespace Application.Features.CustomerEBills.Commands.Delete;

public class DeletedCustomerEBillResponse : IResponse
{
    public int Id { get; set; }
}