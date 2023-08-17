using Core.Application.Dtos;

namespace Application.Features.CommercialTypes.Queries.GetList;

public class GetListCommercialTypeListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}