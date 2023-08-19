using Core.Application.Dtos;

namespace Application.Features.Bookings.Queries.GetList;

public class GetListBookingListItemDto : IDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string? MBLNo { get; set; }
    public string? ProjectNo { get; set; }
    public DateTime? Etd { get; set; }
    public DateTime? Eta { get; set; }
    public string? DeclarationNo { get; set; }
    public DateTime? DeclarationDate { get; set; }
    public DateTime? OrdinoDate { get; set; }
    public string? Region { get; set; }
    public string? Agent { get; set; }
    public string? Note { get; set; }
    public string? IsOrigin { get; set; }
    public string? IsCopy { get; set; }
    public string? FileNo { get; set; }
    public int BookingTypeID { get; set; }
    public int PolID { get; set; }
    public int PodID { get; set; }
    public int? RouteID { get; set; }
    public int ShipID { get; set; }
    public int? ShipVoyageID { get; set; }
    public int FeederID { get; set; }
    public int FeederVoyageID { get; set; }
    public int ShipperID { get; set; }
    public int? ConsigneID { get; set; }
    public int? NotifyID { get; set; }
    public int ApplyToID { get; set; }
    public int? OperationResponsibleID { get; set; }
    public int? MarketingResponsibleID { get; set; }
    public int? DemurrageID { get; set; }
    public int? DetentionID { get; set; }
    public int? FreeDayID { get; set; }
    public int? TotalFeeID { get; set; }
}