using Application.Features.CommercialDetails.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CommercialDetails.Rules;

public class CommercialDetailBusinessRules : BaseBusinessRules
{
    private readonly ICommercialDetailRepository _commercialDetailRepository;

    public CommercialDetailBusinessRules(ICommercialDetailRepository commercialDetailRepository)
    {
        _commercialDetailRepository = commercialDetailRepository;
    }

    public Task CommercialDetailShouldExistWhenSelected(CommercialDetail? commercialDetail)
    {
        if (commercialDetail == null)
            throw new BusinessException(CommercialDetailsBusinessMessages.CommercialDetailNotExists);
        return Task.CompletedTask;
    }

    public async Task CommercialDetailIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CommercialDetail? commercialDetail = await _commercialDetailRepository.GetAsync(
            predicate: cd => cd.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CommercialDetailShouldExistWhenSelected(commercialDetail);
    }
}