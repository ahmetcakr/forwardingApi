using Core.Application.Responses;

namespace Application.Features.CommercialDetails.Commands.Delete;

public class DeletedCommercialDetailResponse : IResponse
{
    public int Id { get; set; }
}