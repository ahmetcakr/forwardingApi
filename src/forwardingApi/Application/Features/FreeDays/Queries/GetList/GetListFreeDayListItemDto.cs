using Core.Application.Dtos;

namespace Application.Features.FreeDays.Queries.GetList;

public class GetListFreeDayListItemDto : IDto
{
    public int Id { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? Day { get; set; }
    public int? Fee { get; set; }
    public int? Total { get; set; }
    public int? TotalFee { get; set; }
}