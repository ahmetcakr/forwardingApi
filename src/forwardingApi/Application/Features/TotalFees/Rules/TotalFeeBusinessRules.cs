using Application.Features.TotalFees.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.TotalFees.Rules;

public class TotalFeeBusinessRules : BaseBusinessRules
{
    private readonly ITotalFeeRepository _totalFeeRepository;

    public TotalFeeBusinessRules(ITotalFeeRepository totalFeeRepository)
    {
        _totalFeeRepository = totalFeeRepository;
    }

    public Task TotalFeeShouldExistWhenSelected(TotalFee? totalFee)
    {
        if (totalFee == null)
            throw new BusinessException(TotalFeesBusinessMessages.TotalFeeNotExists);
        return Task.CompletedTask;
    }

    public async Task TotalFeeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        TotalFee? totalFee = await _totalFeeRepository.GetAsync(
            predicate: tf => tf.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TotalFeeShouldExistWhenSelected(totalFee);
    }
}