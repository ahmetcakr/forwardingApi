using Core.Application.Dtos;

namespace Application.Features.Feeders.Queries.GetList;

public class GetListFeederListItemDto : IDto
{
    public int Id { get; set; }
    public string FeederName { get; set; }
}