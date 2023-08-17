using Core.Application.Dtos;

namespace Application.Features.EBills.Queries.GetList;

public class GetListEBillListItemDto : IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? Mail { get; set; }
}