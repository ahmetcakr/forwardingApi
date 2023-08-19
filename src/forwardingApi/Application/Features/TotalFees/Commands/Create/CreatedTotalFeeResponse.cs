using Core.Application.Responses;

namespace Application.Features.TotalFees.Commands.Create;

public class CreatedTotalFeeResponse : IResponse
{
    public int Id { get; set; }
    public int? Fee { get; set; }
    public int? Vat { get; set; }
    public int? Total { get; set; }
}