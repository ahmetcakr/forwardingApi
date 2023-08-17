using Core.Application.Responses;

namespace Application.Features.CustomerFirmTypes.Commands.Delete;

public class DeletedCustomerFirmTypeResponse : IResponse
{
    public int Id { get; set; }
}