using Core.Application.Responses;

namespace Application.Features.CustomerGroups.Queries.GetById;

public class GetByIdCustomerGroupResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int GroupId { get; set; }
}