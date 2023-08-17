using Core.Application.Responses;

namespace Application.Features.EBills.Queries.GetById;

public class GetByIdEBillResponse : IResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? Mail { get; set; }
}