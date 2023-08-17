using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CommercialTypes;

public interface ICommercialTypesService
{
    Task<CommercialType?> GetAsync(
        Expression<Func<CommercialType, bool>> predicate,
        Func<IQueryable<CommercialType>, IIncludableQueryable<CommercialType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CommercialType>?> GetListAsync(
        Expression<Func<CommercialType, bool>>? predicate = null,
        Func<IQueryable<CommercialType>, IOrderedQueryable<CommercialType>>? orderBy = null,
        Func<IQueryable<CommercialType>, IIncludableQueryable<CommercialType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CommercialType> AddAsync(CommercialType commercialType);
    Task<CommercialType> UpdateAsync(CommercialType commercialType);
    Task<CommercialType> DeleteAsync(CommercialType commercialType, bool permanent = false);
}
