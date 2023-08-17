using Application.Features.CustomerGroups.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CustomerGroups.Rules;

public class CustomerGroupBusinessRules : BaseBusinessRules
{
    private readonly ICustomerGroupRepository _customerGroupRepository;

    public CustomerGroupBusinessRules(ICustomerGroupRepository customerGroupRepository)
    {
        _customerGroupRepository = customerGroupRepository;
    }

    public Task CustomerGroupShouldExistWhenSelected(CustomerGroup? customerGroup)
    {
        if (customerGroup == null)
            throw new BusinessException(CustomerGroupsBusinessMessages.CustomerGroupNotExists);
        return Task.CompletedTask;
    }

    public async Task CustomerGroupIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CustomerGroup? customerGroup = await _customerGroupRepository.GetAsync(
            predicate: cg => cg.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CustomerGroupShouldExistWhenSelected(customerGroup);
    }
}