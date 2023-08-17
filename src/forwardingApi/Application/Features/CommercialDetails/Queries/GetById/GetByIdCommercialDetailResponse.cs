using Core.Application.Responses;

namespace Application.Features.CommercialDetails.Queries.GetById;

public class GetByIdCommercialDetailResponse : IResponse
{
    public int Id { get; set; }
    public string? TaxOffice { get; set; }
    public string? TaxOfficeNo { get; set; }
    public string? Bank { get; set; }
    public string? BankAccountNo { get; set; }
    public string? BankDetail { get; set; }
}