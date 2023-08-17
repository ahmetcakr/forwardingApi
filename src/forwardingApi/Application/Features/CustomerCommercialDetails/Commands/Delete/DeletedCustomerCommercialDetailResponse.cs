using Core.Application.Responses;

namespace Application.Features.CustomerCommercialDetails.Commands.Delete;

public class DeletedCustomerCommercialDetailResponse : IResponse
{
    public int Id { get; set; }
}