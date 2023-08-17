using Application.Features.CommercialTypes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CommercialTypes.Rules;

public class CommercialTypeBusinessRules : BaseBusinessRules
{
    private readonly ICommercialTypeRepository _commercialTypeRepository;

    public CommercialTypeBusinessRules(ICommercialTypeRepository commercialTypeRepository)
    {
        _commercialTypeRepository = commercialTypeRepository;
    }

    public Task CommercialTypeShouldExistWhenSelected(CommercialType? commercialType)
    {
        if (commercialType == null)
            throw new BusinessException(CommercialTypesBusinessMessages.CommercialTypeNotExists);
        return Task.CompletedTask;
    }

    public async Task CommercialTypeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CommercialType? commercialType = await _commercialTypeRepository.GetAsync(
            predicate: ct => ct.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CommercialTypeShouldExistWhenSelected(commercialType);
    }
}