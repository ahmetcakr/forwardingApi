using Application.Features.Groups.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Groups;

public class GroupsManager : IGroupsService
{
    private readonly IGroupRepository _groupRepository;
    private readonly GroupBusinessRules _groupBusinessRules;

    public GroupsManager(IGroupRepository groupRepository, GroupBusinessRules groupBusinessRules)
    {
        _groupRepository = groupRepository;
        _groupBusinessRules = groupBusinessRules;
    }

    public async Task<Group?> GetAsync(
        Expression<Func<Group, bool>> predicate,
        Func<IQueryable<Group>, IIncludableQueryable<Group, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Group? group = await _groupRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return group;
    }

    public async Task<IPaginate<Group>?> GetListAsync(
        Expression<Func<Group, bool>>? predicate = null,
        Func<IQueryable<Group>, IOrderedQueryable<Group>>? orderBy = null,
        Func<IQueryable<Group>, IIncludableQueryable<Group, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Group> groupList = await _groupRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return groupList;
    }

    public async Task<Group> AddAsync(Group group)
    {
        Group addedGroup = await _groupRepository.AddAsync(group);

        return addedGroup;
    }

    public async Task<Group> UpdateAsync(Group group)
    {
        Group updatedGroup = await _groupRepository.UpdateAsync(group);

        return updatedGroup;
    }

    public async Task<Group> DeleteAsync(Group group, bool permanent = false)
    {
        Group deletedGroup = await _groupRepository.DeleteAsync(group);

        return deletedGroup;
    }
}
