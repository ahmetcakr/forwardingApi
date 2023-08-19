using Application.Features.Consignes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Consignes.Rules;

public class ConsigneBusinessRules : BaseBusinessRules
{
    private readonly IConsigneRepository _consigneRepository;

    public ConsigneBusinessRules(IConsigneRepository consigneRepository)
    {
        _consigneRepository = consigneRepository;
    }

    public Task ConsigneShouldExistWhenSelected(Consigne? consigne)
    {
        if (consigne == null)
            throw new BusinessException(ConsignesBusinessMessages.ConsigneNotExists);
        return Task.CompletedTask;
    }

    public async Task ConsigneIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Consigne? consigne = await _consigneRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ConsigneShouldExistWhenSelected(consigne);
    }
}