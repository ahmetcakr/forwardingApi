using Core.Application.Responses;

namespace Application.Features.Pods.Commands.Delete;

public class DeletedPodResponse : IResponse
{
    public int Id { get; set; }
}