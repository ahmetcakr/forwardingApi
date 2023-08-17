using Core.Application.Responses;

namespace Application.Features.Groups.Commands.Delete;

public class DeletedGroupResponse : IResponse
{
    public int Id { get; set; }
}