using Core.Application.Responses;

namespace Application.Features.EBills.Commands.Delete;

public class DeletedEBillResponse : IResponse
{
    public int Id { get; set; }
}