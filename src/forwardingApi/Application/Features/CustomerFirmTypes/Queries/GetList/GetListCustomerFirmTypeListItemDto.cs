using Core.Application.Dtos;

namespace Application.Features.CustomerFirmTypes.Queries.GetList;

public class GetListCustomerFirmTypeListItemDto : IDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int FirmTypeId { get; set; }
}