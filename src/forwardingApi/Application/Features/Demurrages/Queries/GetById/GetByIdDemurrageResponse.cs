using Core.Application.Responses;

namespace Application.Features.Demurrages.Queries.GetById;

public class GetByIdDemurrageResponse : IResponse
{
    public int Id { get; set; }
    public DateTime? StartDate { get; set; }
    public int? Day { get; set; }
    public int? Fee { get; set; }
}