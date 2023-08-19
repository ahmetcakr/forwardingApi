using Application.Features.Pols.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Pols.Rules;

public class PolBusinessRules : BaseBusinessRules
{
    private readonly IPolRepository _polRepository;

    public PolBusinessRules(IPolRepository polRepository)
    {
        _polRepository = polRepository;
    }

    public Task PolShouldExistWhenSelected(Pol? pol)
    {
        if (pol == null)
            throw new BusinessException(PolsBusinessMessages.PolNotExists);
        return Task.CompletedTask;
    }

    public async Task PolIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Pol? pol = await _polRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PolShouldExistWhenSelected(pol);
    }
}