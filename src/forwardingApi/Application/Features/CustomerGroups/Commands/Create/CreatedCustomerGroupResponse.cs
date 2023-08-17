using Core.Application.Responses;

namespace Application.Features.CustomerGroups.Commands.Create;

public class CreatedCustomerGroupResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int GroupId { get; set; }
}