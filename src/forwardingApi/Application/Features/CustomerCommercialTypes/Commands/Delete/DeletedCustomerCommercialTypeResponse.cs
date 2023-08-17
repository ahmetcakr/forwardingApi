using Core.Application.Responses;

namespace Application.Features.CustomerCommercialTypes.Commands.Delete;

public class DeletedCustomerCommercialTypeResponse : IResponse
{
    public int Id { get; set; }
}