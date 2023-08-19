using Core.Application.Dtos;

namespace Application.Features.Voyages.Queries.GetList;

public class GetListVoyageListItemDto : IDto
{
    public int Id { get; set; }
    public string VoyageName { get; set; }
}