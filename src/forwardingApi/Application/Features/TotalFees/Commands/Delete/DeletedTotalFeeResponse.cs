using Core.Application.Responses;

namespace Application.Features.TotalFees.Commands.Delete;

public class DeletedTotalFeeResponse : IResponse
{
    public int Id { get; set; }
}