using Core.Application.Responses;

namespace Application.Features.CustomerFirmTypes.Commands.Create;

public class CreatedCustomerFirmTypeResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int FirmTypeId { get; set; }
}