using Core.Application.Responses;

namespace Application.Features.Pods.Commands.Create;

public class CreatedPodResponse : IResponse
{
    public int Id { get; set; }
    public string PodName { get; set; }
}