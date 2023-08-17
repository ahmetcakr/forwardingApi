using Core.Application.Dtos;

namespace Application.Features.CustomerSectors.Queries.GetList;

public class GetListCustomerSectorListItemDto : IDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int SectorId { get; set; }
}