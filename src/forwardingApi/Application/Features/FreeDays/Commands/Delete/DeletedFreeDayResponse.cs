using Core.Application.Responses;

namespace Application.Features.FreeDays.Commands.Delete;

public class DeletedFreeDayResponse : IResponse
{
    public int Id { get; set; }
}