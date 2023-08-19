using Core.Application.Responses;

namespace Application.Features.Pods.Commands.Update;

public class UpdatedPodResponse : IResponse
{
    public int Id { get; set; }
    public string PodName { get; set; }
}