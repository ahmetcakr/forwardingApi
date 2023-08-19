using Application.Features.Detentions.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Detentions.Rules;

public class DetentionBusinessRules : BaseBusinessRules
{
    private readonly IDetentionRepository _detentionRepository;

    public DetentionBusinessRules(IDetentionRepository detentionRepository)
    {
        _detentionRepository = detentionRepository;
    }

    public Task DetentionShouldExistWhenSelected(Detention? detention)
    {
        if (detention == null)
            throw new BusinessException(DetentionsBusinessMessages.DetentionNotExists);
        return Task.CompletedTask;
    }

    public async Task DetentionIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Detention? detention = await _detentionRepository.GetAsync(
            predicate: d => d.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DetentionShouldExistWhenSelected(detention);
    }
}