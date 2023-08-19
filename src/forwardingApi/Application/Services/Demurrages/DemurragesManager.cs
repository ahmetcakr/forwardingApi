using Application.Features.Demurrages.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Demurrages;

public class DemurragesManager : IDemurragesService
{
    private readonly IDemurrageRepository _demurrageRepository;
    private readonly DemurrageBusinessRules _demurrageBusinessRules;

    public DemurragesManager(IDemurrageRepository demurrageRepository, DemurrageBusinessRules demurrageBusinessRules)
    {
        _demurrageRepository = demurrageRepository;
        _demurrageBusinessRules = demurrageBusinessRules;
    }

    public async Task<Demurrage?> GetAsync(
        Expression<Func<Demurrage, bool>> predicate,
        Func<IQueryable<Demurrage>, IIncludableQueryable<Demurrage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Demurrage? demurrage = await _demurrageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return demurrage;
    }

    public async Task<IPaginate<Demurrage>?> GetListAsync(
        Expression<Func<Demurrage, bool>>? predicate = null,
        Func<IQueryable<Demurrage>, IOrderedQueryable<Demurrage>>? orderBy = null,
        Func<IQueryable<Demurrage>, IIncludableQueryable<Demurrage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Demurrage> demurrageList = await _demurrageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return demurrageList;
    }

    public async Task<Demurrage> AddAsync(Demurrage demurrage)
    {
        Demurrage addedDemurrage = await _demurrageRepository.AddAsync(demurrage);

        return addedDemurrage;
    }

    public async Task<Demurrage> UpdateAsync(Demurrage demurrage)
    {
        Demurrage updatedDemurrage = await _demurrageRepository.UpdateAsync(demurrage);

        return updatedDemurrage;
    }

    public async Task<Demurrage> DeleteAsync(Demurrage demurrage, bool permanent = false)
    {
        Demurrage deletedDemurrage = await _demurrageRepository.DeleteAsync(demurrage);

        return deletedDemurrage;
    }
}
