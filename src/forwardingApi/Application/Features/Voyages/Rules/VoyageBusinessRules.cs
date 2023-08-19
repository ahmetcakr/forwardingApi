using Application.Features.Voyages.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Voyages.Rules;

public class VoyageBusinessRules : BaseBusinessRules
{
    private readonly IVoyageRepository _voyageRepository;

    public VoyageBusinessRules(IVoyageRepository voyageRepository)
    {
        _voyageRepository = voyageRepository;
    }

    public Task VoyageShouldExistWhenSelected(Voyage? voyage)
    {
        if (voyage == null)
            throw new BusinessException(VoyagesBusinessMessages.VoyageNotExists);
        return Task.CompletedTask;
    }

    public async Task VoyageIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Voyage? voyage = await _voyageRepository.GetAsync(
            predicate: v => v.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await VoyageShouldExistWhenSelected(voyage);
    }
}