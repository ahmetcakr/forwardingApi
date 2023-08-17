using Application.Features.CustomerGroups.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerGroups;

public class CustomerGroupsManager : ICustomerGroupsService
{
    private readonly ICustomerGroupRepository _customerGroupRepository;
    private readonly CustomerGroupBusinessRules _customerGroupBusinessRules;

    public CustomerGroupsManager(ICustomerGroupRepository customerGroupRepository, CustomerGroupBusinessRules customerGroupBusinessRules)
    {
        _customerGroupRepository = customerGroupRepository;
        _customerGroupBusinessRules = customerGroupBusinessRules;
    }

    public async Task<CustomerGroup?> GetAsync(
        Expression<Func<CustomerGroup, bool>> predicate,
        Func<IQueryable<CustomerGroup>, IIncludableQueryable<CustomerGroup, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CustomerGroup? customerGroup = await _customerGroupRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return customerGroup;
    }

    public async Task<IPaginate<CustomerGroup>?> GetListAsync(
        Expression<Func<CustomerGroup, bool>>? predicate = null,
        Func<IQueryable<CustomerGroup>, IOrderedQueryable<CustomerGroup>>? orderBy = null,
        Func<IQueryable<CustomerGroup>, IIncludableQueryable<CustomerGroup, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CustomerGroup> customerGroupList = await _customerGroupRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return customerGroupList;
    }

    public async Task<CustomerGroup> AddAsync(CustomerGroup customerGroup)
    {
        CustomerGroup addedCustomerGroup = await _customerGroupRepository.AddAsync(customerGroup);

        return addedCustomerGroup;
    }

    public async Task<CustomerGroup> UpdateAsync(CustomerGroup customerGroup)
    {
        CustomerGroup updatedCustomerGroup = await _customerGroupRepository.UpdateAsync(customerGroup);

        return updatedCustomerGroup;
    }

    public async Task<CustomerGroup> DeleteAsync(CustomerGroup customerGroup, bool permanent = false)
    {
        CustomerGroup deletedCustomerGroup = await _customerGroupRepository.DeleteAsync(customerGroup);

        return deletedCustomerGroup;
    }
}
