using Application.Features.Pols.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Pols;

public class PolsManager : IPolsService
{
    private readonly IPolRepository _polRepository;
    private readonly PolBusinessRules _polBusinessRules;

    public PolsManager(IPolRepository polRepository, PolBusinessRules polBusinessRules)
    {
        _polRepository = polRepository;
        _polBusinessRules = polBusinessRules;
    }

    public async Task<Pol?> GetAsync(
        Expression<Func<Pol, bool>> predicate,
        Func<IQueryable<Pol>, IIncludableQueryable<Pol, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Pol? pol = await _polRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return pol;
    }

    public async Task<IPaginate<Pol>?> GetListAsync(
        Expression<Func<Pol, bool>>? predicate = null,
        Func<IQueryable<Pol>, IOrderedQueryable<Pol>>? orderBy = null,
        Func<IQueryable<Pol>, IIncludableQueryable<Pol, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Pol> polList = await _polRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return polList;
    }

    public async Task<Pol> AddAsync(Pol pol)
    {
        Pol addedPol = await _polRepository.AddAsync(pol);

        return addedPol;
    }

    public async Task<Pol> UpdateAsync(Pol pol)
    {
        Pol updatedPol = await _polRepository.UpdateAsync(pol);

        return updatedPol;
    }

    public async Task<Pol> DeleteAsync(Pol pol, bool permanent = false)
    {
        Pol deletedPol = await _polRepository.DeleteAsync(pol);

        return deletedPol;
    }
}
