using Application.Features.CustomerCommercialTypes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerCommercialTypes;

public class CustomerCommercialTypesManager : ICustomerCommercialTypesService
{
    private readonly ICustomerCommercialTypeRepository _customerCommercialTypeRepository;
    private readonly CustomerCommercialTypeBusinessRules _customerCommercialTypeBusinessRules;

    public CustomerCommercialTypesManager(ICustomerCommercialTypeRepository customerCommercialTypeRepository, CustomerCommercialTypeBusinessRules customerCommercialTypeBusinessRules)
    {
        _customerCommercialTypeRepository = customerCommercialTypeRepository;
        _customerCommercialTypeBusinessRules = customerCommercialTypeBusinessRules;
    }

    public async Task<CustomerCommercialType?> GetAsync(
        Expression<Func<CustomerCommercialType, bool>> predicate,
        Func<IQueryable<CustomerCommercialType>, IIncludableQueryable<CustomerCommercialType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CustomerCommercialType? customerCommercialType = await _customerCommercialTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return customerCommercialType;
    }

    public async Task<IPaginate<CustomerCommercialType>?> GetListAsync(
        Expression<Func<CustomerCommercialType, bool>>? predicate = null,
        Func<IQueryable<CustomerCommercialType>, IOrderedQueryable<CustomerCommercialType>>? orderBy = null,
        Func<IQueryable<CustomerCommercialType>, IIncludableQueryable<CustomerCommercialType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CustomerCommercialType> customerCommercialTypeList = await _customerCommercialTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return customerCommercialTypeList;
    }

    public async Task<CustomerCommercialType> AddAsync(CustomerCommercialType customerCommercialType)
    {
        CustomerCommercialType addedCustomerCommercialType = await _customerCommercialTypeRepository.AddAsync(customerCommercialType);

        return addedCustomerCommercialType;
    }

    public async Task<CustomerCommercialType> UpdateAsync(CustomerCommercialType customerCommercialType)
    {
        CustomerCommercialType updatedCustomerCommercialType = await _customerCommercialTypeRepository.UpdateAsync(customerCommercialType);

        return updatedCustomerCommercialType;
    }

    public async Task<CustomerCommercialType> DeleteAsync(CustomerCommercialType customerCommercialType, bool permanent = false)
    {
        CustomerCommercialType deletedCustomerCommercialType = await _customerCommercialTypeRepository.DeleteAsync(customerCommercialType);

        return deletedCustomerCommercialType;
    }
}
