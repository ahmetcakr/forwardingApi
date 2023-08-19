using Core.Application.Responses;

namespace Application.Features.Pods.Queries.GetById;

public class GetByIdPodResponse : IResponse
{
    public int Id { get; set; }
    public string PodName { get; set; }
}