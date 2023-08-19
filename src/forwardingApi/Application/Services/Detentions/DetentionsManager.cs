using Application.Features.Detentions.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Detentions;

public class DetentionsManager : IDetentionsService
{
    private readonly IDetentionRepository _detentionRepository;
    private readonly DetentionBusinessRules _detentionBusinessRules;

    public DetentionsManager(IDetentionRepository detentionRepository, DetentionBusinessRules detentionBusinessRules)
    {
        _detentionRepository = detentionRepository;
        _detentionBusinessRules = detentionBusinessRules;
    }

    public async Task<Detention?> GetAsync(
        Expression<Func<Detention, bool>> predicate,
        Func<IQueryable<Detention>, IIncludableQueryable<Detention, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Detention? detention = await _detentionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return detention;
    }

    public async Task<IPaginate<Detention>?> GetListAsync(
        Expression<Func<Detention, bool>>? predicate = null,
        Func<IQueryable<Detention>, IOrderedQueryable<Detention>>? orderBy = null,
        Func<IQueryable<Detention>, IIncludableQueryable<Detention, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Detention> detentionList = await _detentionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return detentionList;
    }

    public async Task<Detention> AddAsync(Detention detention)
    {
        Detention addedDetention = await _detentionRepository.AddAsync(detention);

        return addedDetention;
    }

    public async Task<Detention> UpdateAsync(Detention detention)
    {
        Detention updatedDetention = await _detentionRepository.UpdateAsync(detention);

        return updatedDetention;
    }

    public async Task<Detention> DeleteAsync(Detention detention, bool permanent = false)
    {
        Detention deletedDetention = await _detentionRepository.DeleteAsync(detention);

        return deletedDetention;
    }
}
