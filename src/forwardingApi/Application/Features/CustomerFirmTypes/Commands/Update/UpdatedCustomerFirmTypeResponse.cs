using Core.Application.Responses;

namespace Application.Features.CustomerFirmTypes.Commands.Update;

public class UpdatedCustomerFirmTypeResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int FirmTypeId { get; set; }
}