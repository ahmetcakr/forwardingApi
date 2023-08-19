using Core.Application.Responses;

namespace Application.Features.Demurrages.Commands.Create;

public class CreatedDemurrageResponse : IResponse
{
    public int Id { get; set; }
    public DateTime? StartDate { get; set; }
    public int? Day { get; set; }
    public int? Fee { get; set; }
}