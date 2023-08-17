using Core.Application.Responses;

namespace Application.Features.CustomerSectors.Queries.GetById;

public class GetByIdCustomerSectorResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int SectorId { get; set; }
}