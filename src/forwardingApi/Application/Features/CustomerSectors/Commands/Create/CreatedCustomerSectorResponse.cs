using Core.Application.Responses;

namespace Application.Features.CustomerSectors.Commands.Create;

public class CreatedCustomerSectorResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int SectorId { get; set; }
}