using Application.Features.FreeDays.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FreeDays;

public class FreeDaysManager : IFreeDaysService
{
    private readonly IFreeDayRepository _freeDayRepository;
    private readonly FreeDayBusinessRules _freeDayBusinessRules;

    public FreeDaysManager(IFreeDayRepository freeDayRepository, FreeDayBusinessRules freeDayBusinessRules)
    {
        _freeDayRepository = freeDayRepository;
        _freeDayBusinessRules = freeDayBusinessRules;
    }

    public async Task<FreeDay?> GetAsync(
        Expression<Func<FreeDay, bool>> predicate,
        Func<IQueryable<FreeDay>, IIncludableQueryable<FreeDay, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        FreeDay? freeDay = await _freeDayRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return freeDay;
    }

    public async Task<IPaginate<FreeDay>?> GetListAsync(
        Expression<Func<FreeDay, bool>>? predicate = null,
        Func<IQueryable<FreeDay>, IOrderedQueryable<FreeDay>>? orderBy = null,
        Func<IQueryable<FreeDay>, IIncludableQueryable<FreeDay, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<FreeDay> freeDayList = await _freeDayRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return freeDayList;
    }

    public async Task<FreeDay> AddAsync(FreeDay freeDay)
    {
        FreeDay addedFreeDay = await _freeDayRepository.AddAsync(freeDay);

        return addedFreeDay;
    }

    public async Task<FreeDay> UpdateAsync(FreeDay freeDay)
    {
        FreeDay updatedFreeDay = await _freeDayRepository.UpdateAsync(freeDay);

        return updatedFreeDay;
    }

    public async Task<FreeDay> DeleteAsync(FreeDay freeDay, bool permanent = false)
    {
        FreeDay deletedFreeDay = await _freeDayRepository.DeleteAsync(freeDay);

        return deletedFreeDay;
    }
}
