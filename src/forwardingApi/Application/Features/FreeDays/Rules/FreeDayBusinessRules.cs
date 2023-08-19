using Application.Features.FreeDays.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.FreeDays.Rules;

public class FreeDayBusinessRules : BaseBusinessRules
{
    private readonly IFreeDayRepository _freeDayRepository;

    public FreeDayBusinessRules(IFreeDayRepository freeDayRepository)
    {
        _freeDayRepository = freeDayRepository;
    }

    public Task FreeDayShouldExistWhenSelected(FreeDay? freeDay)
    {
        if (freeDay == null)
            throw new BusinessException(FreeDaysBusinessMessages.FreeDayNotExists);
        return Task.CompletedTask;
    }

    public async Task FreeDayIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        FreeDay? freeDay = await _freeDayRepository.GetAsync(
            predicate: fd => fd.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await FreeDayShouldExistWhenSelected(freeDay);
    }
}