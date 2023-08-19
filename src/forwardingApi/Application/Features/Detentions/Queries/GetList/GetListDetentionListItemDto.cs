using Core.Application.Dtos;

namespace Application.Features.Detentions.Queries.GetList;

public class GetListDetentionListItemDto : IDto
{
    public int Id { get; set; }
    public int? Day { get; set; }
    public int? Fee { get; set; }
}