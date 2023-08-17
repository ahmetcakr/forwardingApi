using Core.Application.Responses;

namespace Application.Features.CustomerFirmTypes.Queries.GetById;

public class GetByIdCustomerFirmTypeResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int FirmTypeId { get; set; }
}