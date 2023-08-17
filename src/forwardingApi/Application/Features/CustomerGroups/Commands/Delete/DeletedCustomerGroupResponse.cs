using Core.Application.Responses;

namespace Application.Features.CustomerGroups.Commands.Delete;

public class DeletedCustomerGroupResponse : IResponse
{
    public int Id { get; set; }
}