using Core.Application.Responses;

namespace Application.Features.CommercialTypes.Commands.Delete;

public class DeletedCommercialTypeResponse : IResponse
{
    public int Id { get; set; }
}