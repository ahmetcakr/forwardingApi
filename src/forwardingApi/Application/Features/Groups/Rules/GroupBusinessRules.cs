using Application.Features.Groups.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Groups.Rules;

public class GroupBusinessRules : BaseBusinessRules
{
    private readonly IGroupRepository _groupRepository;

    public GroupBusinessRules(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public Task GroupShouldExistWhenSelected(Group? group)
    {
        if (group == null)
            throw new BusinessException(GroupsBusinessMessages.GroupNotExists);
        return Task.CompletedTask;
    }

    public async Task GroupIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Group? group = await _groupRepository.GetAsync(
            predicate: g => g.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await GroupShouldExistWhenSelected(group);
    }
}