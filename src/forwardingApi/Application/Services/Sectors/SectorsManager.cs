using Application.Features.Sectors.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Sectors;

public class SectorsManager : ISectorsService
{
    private readonly ISectorRepository _sectorRepository;
    private readonly SectorBusinessRules _sectorBusinessRules;

    public SectorsManager(ISectorRepository sectorRepository, SectorBusinessRules sectorBusinessRules)
    {
        _sectorRepository = sectorRepository;
        _sectorBusinessRules = sectorBusinessRules;
    }

    public async Task<Sector?> GetAsync(
        Expression<Func<Sector, bool>> predicate,
        Func<IQueryable<Sector>, IIncludableQueryable<Sector, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Sector? sector = await _sectorRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return sector;
    }

    public async Task<IPaginate<Sector>?> GetListAsync(
        Expression<Func<Sector, bool>>? predicate = null,
        Func<IQueryable<Sector>, IOrderedQueryable<Sector>>? orderBy = null,
        Func<IQueryable<Sector>, IIncludableQueryable<Sector, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Sector> sectorList = await _sectorRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return sectorList;
    }

    public async Task<Sector> AddAsync(Sector sector)
    {
        Sector addedSector = await _sectorRepository.AddAsync(sector);

        return addedSector;
    }

    public async Task<Sector> UpdateAsync(Sector sector)
    {
        Sector updatedSector = await _sectorRepository.UpdateAsync(sector);

        return updatedSector;
    }

    public async Task<Sector> DeleteAsync(Sector sector, bool permanent = false)
    {
        Sector deletedSector = await _sectorRepository.DeleteAsync(sector);

        return deletedSector;
    }
}
