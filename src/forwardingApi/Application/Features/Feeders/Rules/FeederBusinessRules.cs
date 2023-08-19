using Application.Features.Feeders.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Feeders.Rules;

public class FeederBusinessRules : BaseBusinessRules
{
    private readonly IFeederRepository _feederRepository;

    public FeederBusinessRules(IFeederRepository feederRepository)
    {
        _feederRepository = feederRepository;
    }

    public Task FeederShouldExistWhenSelected(Feeder? feeder)
    {
        if (feeder == null)
            throw new BusinessException(FeedersBusinessMessages.FeederNotExists);
        return Task.CompletedTask;
    }

    public async Task FeederIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Feeder? feeder = await _feederRepository.GetAsync(
            predicate: f => f.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await FeederShouldExistWhenSelected(feeder);
    }
}