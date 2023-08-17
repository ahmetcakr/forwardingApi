using Application.Features.CustomerFirmTypes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerFirmTypes;

public class CustomerFirmTypesManager : ICustomerFirmTypesService
{
    private readonly ICustomerFirmTypeRepository _customerFirmTypeRepository;
    private readonly CustomerFirmTypeBusinessRules _customerFirmTypeBusinessRules;

    public CustomerFirmTypesManager(ICustomerFirmTypeRepository customerFirmTypeRepository, CustomerFirmTypeBusinessRules customerFirmTypeBusinessRules)
    {
        _customerFirmTypeRepository = customerFirmTypeRepository;
        _customerFirmTypeBusinessRules = customerFirmTypeBusinessRules;
    }

    public async Task<CustomerFirmType?> GetAsync(
        Expression<Func<CustomerFirmType, bool>> predicate,
        Func<IQueryable<CustomerFirmType>, IIncludableQueryable<CustomerFirmType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CustomerFirmType? customerFirmType = await _customerFirmTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return customerFirmType;
    }

    public async Task<IPaginate<CustomerFirmType>?> GetListAsync(
        Expression<Func<CustomerFirmType, bool>>? predicate = null,
        Func<IQueryable<CustomerFirmType>, IOrderedQueryable<CustomerFirmType>>? orderBy = null,
        Func<IQueryable<CustomerFirmType>, IIncludableQueryable<CustomerFirmType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CustomerFirmType> customerFirmTypeList = await _customerFirmTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return customerFirmTypeList;
    }

    public async Task<CustomerFirmType> AddAsync(CustomerFirmType customerFirmType)
    {
        CustomerFirmType addedCustomerFirmType = await _customerFirmTypeRepository.AddAsync(customerFirmType);

        return addedCustomerFirmType;
    }

    public async Task<CustomerFirmType> UpdateAsync(CustomerFirmType customerFirmType)
    {
        CustomerFirmType updatedCustomerFirmType = await _customerFirmTypeRepository.UpdateAsync(customerFirmType);

        return updatedCustomerFirmType;
    }

    public async Task<CustomerFirmType> DeleteAsync(CustomerFirmType customerFirmType, bool permanent = false)
    {
        CustomerFirmType deletedCustomerFirmType = await _customerFirmTypeRepository.DeleteAsync(customerFirmType);

        return deletedCustomerFirmType;
    }
}
