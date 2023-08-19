using Core.Application.Responses;

namespace Application.Features.FreeDays.Commands.Create;

public class CreatedFreeDayResponse : IResponse
{
    public int Id { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? Day { get; set; }
    public int? Fee { get; set; }
    public int? Total { get; set; }
    public int? TotalFee { get; set; }
}