using Core.Application.Responses;

namespace Application.Features.CustomerGroups.Commands.Update;

public class UpdatedCustomerGroupResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int GroupId { get; set; }
}