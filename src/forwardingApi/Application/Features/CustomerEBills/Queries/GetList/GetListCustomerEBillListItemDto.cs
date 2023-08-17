using Core.Application.Dtos;

namespace Application.Features.CustomerEBills.Queries.GetList;

public class GetListCustomerEBillListItemDto : IDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int EBillId { get; set; }
}