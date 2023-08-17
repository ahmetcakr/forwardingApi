using Core.Application.Dtos;

namespace Application.Features.CommercialDetails.Queries.GetList;

public class GetListCommercialDetailListItemDto : IDto
{
    public int Id { get; set; }
    public string? TaxOffice { get; set; }
    public string? TaxOfficeNo { get; set; }
    public string? Bank { get; set; }
    public string? BankAccountNo { get; set; }
    public string? BankDetail { get; set; }
}