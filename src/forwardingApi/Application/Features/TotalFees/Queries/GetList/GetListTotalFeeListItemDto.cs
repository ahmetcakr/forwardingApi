using Core.Application.Dtos;

namespace Application.Features.TotalFees.Queries.GetList;

public class GetListTotalFeeListItemDto : IDto
{
    public int Id { get; set; }
    public int? Fee { get; set; }
    public int? Vat { get; set; }
    public int? Total { get; set; }
}