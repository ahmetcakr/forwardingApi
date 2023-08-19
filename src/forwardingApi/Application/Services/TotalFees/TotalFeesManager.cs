using Application.Features.TotalFees.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TotalFees;

public class TotalFeesManager : ITotalFeesService
{
    private readonly ITotalFeeRepository _totalFeeRepository;
    private readonly TotalFeeBusinessRules _totalFeeBusinessRules;

    public TotalFeesManager(ITotalFeeRepository totalFeeRepository, TotalFeeBusinessRules totalFeeBusinessRules)
    {
        _totalFeeRepository = totalFeeRepository;
        _totalFeeBusinessRules = totalFeeBusinessRules;
    }

    public async Task<TotalFee?> GetAsync(
        Expression<Func<TotalFee, bool>> predicate,
        Func<IQueryable<TotalFee>, IIncludableQueryable<TotalFee, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        TotalFee? totalFee = await _totalFeeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return totalFee;
    }

    public async Task<IPaginate<TotalFee>?> GetListAsync(
        Expression<Func<TotalFee, bool>>? predicate = null,
        Func<IQueryable<TotalFee>, IOrderedQueryable<TotalFee>>? orderBy = null,
        Func<IQueryable<TotalFee>, IIncludableQueryable<TotalFee, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<TotalFee> totalFeeList = await _totalFeeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return totalFeeList;
    }

    public async Task<TotalFee> AddAsync(TotalFee totalFee)
    {
        TotalFee addedTotalFee = await _totalFeeRepository.AddAsync(totalFee);

        return addedTotalFee;
    }

    public async Task<TotalFee> UpdateAsync(TotalFee totalFee)
    {
        TotalFee updatedTotalFee = await _totalFeeRepository.UpdateAsync(totalFee);

        return updatedTotalFee;
    }

    public async Task<TotalFee> DeleteAsync(TotalFee totalFee, bool permanent = false)
    {
        TotalFee deletedTotalFee = await _totalFeeRepository.DeleteAsync(totalFee);

        return deletedTotalFee;
    }
}
