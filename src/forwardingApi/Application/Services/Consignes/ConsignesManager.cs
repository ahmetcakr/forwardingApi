using Application.Features.Consignes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Consignes;

public class ConsignesManager : IConsignesService
{
    private readonly IConsigneRepository _consigneRepository;
    private readonly ConsigneBusinessRules _consigneBusinessRules;

    public ConsignesManager(IConsigneRepository consigneRepository, ConsigneBusinessRules consigneBusinessRules)
    {
        _consigneRepository = consigneRepository;
        _consigneBusinessRules = consigneBusinessRules;
    }

    public async Task<Consigne?> GetAsync(
        Expression<Func<Consigne, bool>> predicate,
        Func<IQueryable<Consigne>, IIncludableQueryable<Consigne, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Consigne? consigne = await _consigneRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return consigne;
    }

    public async Task<IPaginate<Consigne>?> GetListAsync(
        Expression<Func<Consigne, bool>>? predicate = null,
        Func<IQueryable<Consigne>, IOrderedQueryable<Consigne>>? orderBy = null,
        Func<IQueryable<Consigne>, IIncludableQueryable<Consigne, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Consigne> consigneList = await _consigneRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return consigneList;
    }

    public async Task<Consigne> AddAsync(Consigne consigne)
    {
        Consigne addedConsigne = await _consigneRepository.AddAsync(consigne);

        return addedConsigne;
    }

    public async Task<Consigne> UpdateAsync(Consigne consigne)
    {
        Consigne updatedConsigne = await _consigneRepository.UpdateAsync(consigne);

        return updatedConsigne;
    }

    public async Task<Consigne> DeleteAsync(Consigne consigne, bool permanent = false)
    {
        Consigne deletedConsigne = await _consigneRepository.DeleteAsync(consigne);

        return deletedConsigne;
    }
}
