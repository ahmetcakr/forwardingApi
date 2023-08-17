using Core.Application.Responses;

namespace Application.Features.Groups.Queries.GetById;

public class GetByIdGroupResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}