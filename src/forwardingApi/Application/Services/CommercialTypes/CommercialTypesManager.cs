using Application.Features.CommercialTypes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CommercialTypes;

public class CommercialTypesManager : ICommercialTypesService
{
    private readonly ICommercialTypeRepository _commercialTypeRepository;
    private readonly CommercialTypeBusinessRules _commercialTypeBusinessRules;

    public CommercialTypesManager(ICommercialTypeRepository commercialTypeRepository, CommercialTypeBusinessRules commercialTypeBusinessRules)
    {
        _commercialTypeRepository = commercialTypeRepository;
        _commercialTypeBusinessRules = commercialTypeBusinessRules;
    }

    public async Task<CommercialType?> GetAsync(
        Expression<Func<CommercialType, bool>> predicate,
        Func<IQueryable<CommercialType>, IIncludableQueryable<CommercialType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CommercialType? commercialType = await _commercialTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return commercialType;
    }

    public async Task<IPaginate<CommercialType>?> GetListAsync(
        Expression<Func<CommercialType, bool>>? predicate = null,
        Func<IQueryable<CommercialType>, IOrderedQueryable<CommercialType>>? orderBy = null,
        Func<IQueryable<CommercialType>, IIncludableQueryable<CommercialType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CommercialType> commercialTypeList = await _commercialTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return commercialTypeList;
    }

    public async Task<CommercialType> AddAsync(CommercialType commercialType)
    {
        CommercialType addedCommercialType = await _commercialTypeRepository.AddAsync(commercialType);

        return addedCommercialType;
    }

    public async Task<CommercialType> UpdateAsync(CommercialType commercialType)
    {
        CommercialType updatedCommercialType = await _commercialTypeRepository.UpdateAsync(commercialType);

        return updatedCommercialType;
    }

    public async Task<CommercialType> DeleteAsync(CommercialType commercialType, bool permanent = false)
    {
        CommercialType deletedCommercialType = await _commercialTypeRepository.DeleteAsync(commercialType);

        return deletedCommercialType;
    }
}
