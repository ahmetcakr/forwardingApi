using Core.Application.Responses;

namespace Application.Features.CustomerSectors.Commands.Delete;

public class DeletedCustomerSectorResponse : IResponse
{
    public int Id { get; set; }
}