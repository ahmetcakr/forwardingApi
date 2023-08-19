using Core.Application.Dtos;

namespace Application.Features.Consignes.Queries.GetList;

public class GetListConsigneListItemDto : IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}