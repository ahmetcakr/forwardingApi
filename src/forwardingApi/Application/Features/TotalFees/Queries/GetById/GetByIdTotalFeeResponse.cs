using Core.Application.Responses;

namespace Application.Features.TotalFees.Queries.GetById;

public class GetByIdTotalFeeResponse : IResponse
{
    public int Id { get; set; }
    public int? Fee { get; set; }
    public int? Vat { get; set; }
    public int? Total { get; set; }
}