using Application.Features.FirmTypes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FirmTypes;

public class FirmTypesManager : IFirmTypesService
{
    private readonly IFirmTypeRepository _firmTypeRepository;
    private readonly FirmTypeBusinessRules _firmTypeBusinessRules;

    public FirmTypesManager(IFirmTypeRepository firmTypeRepository, FirmTypeBusinessRules firmTypeBusinessRules)
    {
        _firmTypeRepository = firmTypeRepository;
        _firmTypeBusinessRules = firmTypeBusinessRules;
    }

    public async Task<FirmType?> GetAsync(
        Expression<Func<FirmType, bool>> predicate,
        Func<IQueryable<FirmType>, IIncludableQueryable<FirmType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        FirmType? firmType = await _firmTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return firmType;
    }

    public async Task<IPaginate<FirmType>?> GetListAsync(
        Expression<Func<FirmType, bool>>? predicate = null,
        Func<IQueryable<FirmType>, IOrderedQueryable<FirmType>>? orderBy = null,
        Func<IQueryable<FirmType>, IIncludableQueryable<FirmType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<FirmType> firmTypeList = await _firmTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return firmTypeList;
    }

    public async Task<FirmType> AddAsync(FirmType firmType)
    {
        FirmType addedFirmType = await _firmTypeRepository.AddAsync(firmType);

        return addedFirmType;
    }

    public async Task<FirmType> UpdateAsync(FirmType firmType)
    {
        FirmType updatedFirmType = await _firmTypeRepository.UpdateAsync(firmType);

        return updatedFirmType;
    }

    public async Task<FirmType> DeleteAsync(FirmType firmType, bool permanent = false)
    {
        FirmType deletedFirmType = await _firmTypeRepository.DeleteAsync(firmType);

        return deletedFirmType;
    }
}
