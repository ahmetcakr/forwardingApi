using Domain.Entities;

namespace Application.Features.Models.Queries.GetList;

public class GetListCustomerListItemDto
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

    public  CommercialDetail? CommercialDetail { get; set; }
    public  CommercialType? CommercialType { get; set; }
    public  EBill? EBill { get; set; }
    public  FirmType? FirmType { get; set; }
    public Group? Group { get; set; }
    public  Sector? Sector { get; set; }
}
