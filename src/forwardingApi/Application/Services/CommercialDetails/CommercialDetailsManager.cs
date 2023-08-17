using Application.Features.CommercialDetails.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CommercialDetails;

public class CommercialDetailsManager : ICommercialDetailsService
{
    private readonly ICommercialDetailRepository _commercialDetailRepository;
    private readonly CommercialDetailBusinessRules _commercialDetailBusinessRules;

    public CommercialDetailsManager(ICommercialDetailRepository commercialDetailRepository, CommercialDetailBusinessRules commercialDetailBusinessRules)
    {
        _commercialDetailRepository = commercialDetailRepository;
        _commercialDetailBusinessRules = commercialDetailBusinessRules;
    }

    public async Task<CommercialDetail?> GetAsync(
        Expression<Func<CommercialDetail, bool>> predicate,
        Func<IQueryable<CommercialDetail>, IIncludableQueryable<CommercialDetail, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CommercialDetail? commercialDetail = await _commercialDetailRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return commercialDetail;
    }

    public async Task<IPaginate<CommercialDetail>?> GetListAsync(
        Expression<Func<CommercialDetail, bool>>? predicate = null,
        Func<IQueryable<CommercialDetail>, IOrderedQueryable<CommercialDetail>>? orderBy = null,
        Func<IQueryable<CommercialDetail>, IIncludableQueryable<CommercialDetail, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CommercialDetail> commercialDetailList = await _commercialDetailRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return commercialDetailList;
    }

    public async Task<CommercialDetail> AddAsync(CommercialDetail commercialDetail)
    {
        CommercialDetail addedCommercialDetail = await _commercialDetailRepository.AddAsync(commercialDetail);

        return addedCommercialDetail;
    }

    public async Task<CommercialDetail> UpdateAsync(CommercialDetail commercialDetail)
    {
        CommercialDetail updatedCommercialDetail = await _commercialDetailRepository.UpdateAsync(commercialDetail);

        return updatedCommercialDetail;
    }

    public async Task<CommercialDetail> DeleteAsync(CommercialDetail commercialDetail, bool permanent = false)
    {
        CommercialDetail deletedCommercialDetail = await _commercialDetailRepository.DeleteAsync(commercialDetail);

        return deletedCommercialDetail;
    }
}
