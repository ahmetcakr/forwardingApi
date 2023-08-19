using Core.Application.Dtos;

namespace Application.Features.Demurrages.Queries.GetList;

public class GetListDemurrageListItemDto : IDto
{
    public int Id { get; set; }
    public DateTime? StartDate { get; set; }
    public int? Day { get; set; }
    public int? Fee { get; set; }
}