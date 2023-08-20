using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Customer : Entity<int>
{
    public string? CustomerCode { get; set; }
    public string? CustomerName { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Region { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? Mail { get; set; }
    public int? CommercialDetailId { get; set; }
    public int? CommercialTypeId { get; set; }
    public int? EBillId { get; set; }
    public int? FirmTypeId { get; set; }
    public int? GroupId { get; set; }
    public int? SectorId { get; set; }

    public virtual CommercialDetail? CommercialDetail { get; set; }
    public virtual CommercialType? CommercialType { get; set; }
    public virtual EBill? EBill { get; set; }
    public virtual FirmType? FirmType { get; set; }
    public virtual Group? Group { get; set; }
    public virtual Sector? Sector { get; set; }

}
