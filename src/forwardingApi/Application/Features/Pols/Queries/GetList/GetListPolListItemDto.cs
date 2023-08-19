using Core.Application.Dtos;

namespace Application.Features.Pols.Queries.GetList;

public class GetListPolListItemDto : IDto
{
    public int Id { get; set; }
    public string PolName { get; set; }
}