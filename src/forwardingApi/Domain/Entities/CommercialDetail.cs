using Core.Persistence.Repositories;

namespace Domain.Entities;

public class CommercialDetail : Entity<int>
{
    public string? TaxOffice { get; set; }
    public string? TaxOfficeNo { get; set; }
    public string? Bank { get; set; }
    public string? BankAccountNo { get; set; }
    public string? BankDetail { get; set; }
}
