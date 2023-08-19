using Application.Features.Demurrages.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Demurrages.Rules;

public class DemurrageBusinessRules : BaseBusinessRules
{
    private readonly IDemurrageRepository _demurrageRepository;

    public DemurrageBusinessRules(IDemurrageRepository demurrageRepository)
    {
        _demurrageRepository = demurrageRepository;
    }

    public Task DemurrageShouldExistWhenSelected(Demurrage? demurrage)
    {
        if (demurrage == null)
            throw new BusinessException(DemurragesBusinessMessages.DemurrageNotExists);
        return Task.CompletedTask;
    }

    public async Task DemurrageIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Demurrage? demurrage = await _demurrageRepository.GetAsync(
            predicate: d => d.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DemurrageShouldExistWhenSelected(demurrage);
    }
}