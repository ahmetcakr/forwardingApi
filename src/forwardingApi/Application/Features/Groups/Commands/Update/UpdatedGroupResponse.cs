using Core.Application.Responses;

namespace Application.Features.Groups.Commands.Update;

public class UpdatedGroupResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}