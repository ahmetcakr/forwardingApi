using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetListByDynamic;

public class GetListByDynamicListItemDto
{
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
    public FreeDay? FreeDay { get; set; }
    public TotalFee? TotalFee { get; set; }
    public Route? Route { get; set; }
    public Company? Company { get; set; }
    public Feeder? Feeder { get; set; }
    public Voyage? FeederVoyage { get; set; }
    public Ship? Ship { get; set; }
    public Voyage? ShipVoyage { get; set; }
    public Customer? Shipper { get; set; }
    public Customer? Consigne { get; set; }
    public Customer? Notify { get; set; }
    public Customer? ApplyTo { get; set; }
    public User? OperationResponsible { get; set; }
    public User? MarketingResponsible { get; set; }


}
