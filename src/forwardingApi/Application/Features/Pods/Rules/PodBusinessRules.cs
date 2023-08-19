using Application.Features.Pods.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Pods.Rules;

public class PodBusinessRules : BaseBusinessRules
{
    private readonly IPodRepository _podRepository;

    public PodBusinessRules(IPodRepository podRepository)
    {
        _podRepository = podRepository;
    }

    public Task PodShouldExistWhenSelected(Pod? pod)
    {
        if (pod == null)
            throw new BusinessException(PodsBusinessMessages.PodNotExists);
        return Task.CompletedTask;
    }

    public async Task PodIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Pod? pod = await _podRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PodShouldExistWhenSelected(pod);
    }
}