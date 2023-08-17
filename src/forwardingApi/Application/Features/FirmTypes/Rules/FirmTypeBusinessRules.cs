using Application.Features.FirmTypes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.FirmTypes.Rules;

public class FirmTypeBusinessRules : BaseBusinessRules
{
    private readonly IFirmTypeRepository _firmTypeRepository;

    public FirmTypeBusinessRules(IFirmTypeRepository firmTypeRepository)
    {
        _firmTypeRepository = firmTypeRepository;
    }

    public Task FirmTypeShouldExistWhenSelected(FirmType? firmType)
    {
        if (firmType == null)
            throw new BusinessException(FirmTypesBusinessMessages.FirmTypeNotExists);
        return Task.CompletedTask;
    }

    public async Task FirmTypeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        FirmType? firmType = await _firmTypeRepository.GetAsync(
            predicate: ft => ft.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await FirmTypeShouldExistWhenSelected(firmType);
    }
}