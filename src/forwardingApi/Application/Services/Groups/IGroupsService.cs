using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Groups;

public interface IGroupsService
{
    Task<Group?> GetAsync(
        Expression<Func<Group, bool>> predicate,
        Func<IQueryable<Group>, IIncludableQueryable<Group, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Group>?> GetListAsync(
        Expression<Func<Group, bool>>? predicate = null,
        Func<IQueryable<Group>, IOrderedQueryable<Group>>? orderBy = null,
        Func<IQueryable<Group>, IIncludableQueryable<Group, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Group> AddAsync(Group group);
    Task<Group> UpdateAsync(Group group);
    Task<Group> DeleteAsync(Group group, bool permanent = false);
}
