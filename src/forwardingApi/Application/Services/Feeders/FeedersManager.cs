using Application.Features.Feeders.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Feeders;

public class FeedersManager : IFeedersService
{
    private readonly IFeederRepository _feederRepository;
    private readonly FeederBusinessRules _feederBusinessRules;

    public FeedersManager(IFeederRepository feederRepository, FeederBusinessRules feederBusinessRules)
    {
        _feederRepository = feederRepository;
        _feederBusinessRules = feederBusinessRules;
    }

    public async Task<Feeder?> GetAsync(
        Expression<Func<Feeder, bool>> predicate,
        Func<IQueryable<Feeder>, IIncludableQueryable<Feeder, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Feeder? feeder = await _feederRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return feeder;
    }

    public async Task<IPaginate<Feeder>?> GetListAsync(
        Expression<Func<Feeder, bool>>? predicate = null,
        Func<IQueryable<Feeder>, IOrderedQueryable<Feeder>>? orderBy = null,
        Func<IQueryable<Feeder>, IIncludableQueryable<Feeder, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Feeder> feederList = await _feederRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return feederList;
    }

    public async Task<Feeder> AddAsync(Feeder feeder)
    {
        Feeder addedFeeder = await _feederRepository.AddAsync(feeder);

        return addedFeeder;
    }

    public async Task<Feeder> UpdateAsync(Feeder feeder)
    {
        Feeder updatedFeeder = await _feederRepository.UpdateAsync(feeder);

        return updatedFeeder;
    }

    public async Task<Feeder> DeleteAsync(Feeder feeder, bool permanent = false)
    {
        Feeder deletedFeeder = await _feederRepository.DeleteAsync(feeder);

        return deletedFeeder;
    }
}
