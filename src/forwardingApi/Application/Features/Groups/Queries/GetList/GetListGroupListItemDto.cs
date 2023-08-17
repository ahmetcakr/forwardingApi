using Core.Application.Dtos;

namespace Application.Features.Groups.Queries.GetList;

public class GetListGroupListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}