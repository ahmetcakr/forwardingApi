using Core.Application.Dtos;

namespace Application.Features.CustomerGroups.Queries.GetList;

public class GetListCustomerGroupListItemDto : IDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int GroupId { get; set; }
}