using Core.Application.Dtos;

namespace Application.Features.Sectors.Queries.GetList;

public class GetListSectorListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}