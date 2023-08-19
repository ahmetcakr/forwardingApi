using Application.Features.Voyages.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Voyages;

public class VoyagesManager : IVoyagesService
{
    private readonly IVoyageRepository _voyageRepository;
    private readonly VoyageBusinessRules _voyageBusinessRules;

    public VoyagesManager(IVoyageRepository voyageRepository, VoyageBusinessRules voyageBusinessRules)
    {
        _voyageRepository = voyageRepository;
        _voyageBusinessRules = voyageBusinessRules;
    }

    public async Task<Voyage?> GetAsync(
        Expression<Func<Voyage, bool>> predicate,
        Func<IQueryable<Voyage>, IIncludableQueryable<Voyage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Voyage? voyage = await _voyageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return voyage;
    }

    public async Task<IPaginate<Voyage>?> GetListAsync(
        Expression<Func<Voyage, bool>>? predicate = null,
        Func<IQueryable<Voyage>, IOrderedQueryable<Voyage>>? orderBy = null,
        Func<IQueryable<Voyage>, IIncludableQueryable<Voyage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Voyage> voyageList = await _voyageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return voyageList;
    }

    public async Task<Voyage> AddAsync(Voyage voyage)
    {
        Voyage addedVoyage = await _voyageRepository.AddAsync(voyage);

        return addedVoyage;
    }

    public async Task<Voyage> UpdateAsync(Voyage voyage)
    {
        Voyage updatedVoyage = await _voyageRepository.UpdateAsync(voyage);

        return updatedVoyage;
    }

    public async Task<Voyage> DeleteAsync(Voyage voyage, bool permanent = false)
    {
        Voyage deletedVoyage = await _voyageRepository.DeleteAsync(voyage);

        return deletedVoyage;
    }
}
