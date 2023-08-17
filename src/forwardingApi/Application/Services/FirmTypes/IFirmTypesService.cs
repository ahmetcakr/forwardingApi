using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FirmTypes;

public interface IFirmTypesService
{
    Task<FirmType?> GetAsync(
        Expression<Func<FirmType, bool>> predicate,
        Func<IQueryable<FirmType>, IIncludableQueryable<FirmType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<FirmType>?> GetListAsync(
        Expression<Func<FirmType, bool>>? predicate = null,
        Func<IQueryable<FirmType>, IOrderedQueryable<FirmType>>? orderBy = null,
        Func<IQueryable<FirmType>, IIncludableQueryable<FirmType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<FirmType> AddAsync(FirmType firmType);
    Task<FirmType> UpdateAsync(FirmType firmType);
    Task<FirmType> DeleteAsync(FirmType firmType, bool permanent = false);
}
