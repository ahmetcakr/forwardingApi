using Core.Application.Dtos;

namespace Application.Features.CustomerCommercialTypes.Queries.GetList;

public class GetListCustomerCommercialTypeListItemDto : IDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CommercialTypeId { get; set; }
}