using Core.Application.Dtos;

namespace Application.Features.CustomerCommercialDetails.Queries.GetList;

public class GetListCustomerCommercialDetailListItemDto : IDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CommercialDetailId { get; set; }
}