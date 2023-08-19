using Core.Application.Dtos;

namespace Application.Features.Pods.Queries.GetList;

public class GetListPodListItemDto : IDto
{
    public int Id { get; set; }
    public string PodName { get; set; }
}