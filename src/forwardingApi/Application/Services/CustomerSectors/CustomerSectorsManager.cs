using Application.Features.CustomerSectors.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerSectors;

public class CustomerSectorsManager : ICustomerSectorsService
{
    private readonly ICustomerSectorRepository _customerSectorRepository;
    private readonly CustomerSectorBusinessRules _customerSectorBusinessRules;

    public CustomerSectorsManager(ICustomerSectorRepository customerSectorRepository, CustomerSectorBusinessRules customerSectorBusinessRules)
    {
        _customerSectorRepository = customerSectorRepository;
        _customerSectorBusinessRules = customerSectorBusinessRules;
    }

    public async Task<CustomerSector?> GetAsync(
        Expression<Func<CustomerSector, bool>> predicate,
        Func<IQueryable<CustomerSector>, IIncludableQueryable<CustomerSector, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CustomerSector? customerSector = await _customerSectorRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return customerSector;
    }

    public async Task<IPaginate<CustomerSector>?> GetListAsync(
        Expression<Func<CustomerSector, bool>>? predicate = null,
        Func<IQueryable<CustomerSector>, IOrderedQueryable<CustomerSector>>? orderBy = null,
        Func<IQueryable<CustomerSector>, IIncludableQueryable<CustomerSector, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CustomerSector> customerSectorList = await _customerSectorRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return customerSectorList;
    }

    public async Task<CustomerSector> AddAsync(CustomerSector customerSector)
    {
        CustomerSector addedCustomerSector = await _customerSectorRepository.AddAsync(customerSector);

        return addedCustomerSector;
    }

    public async Task<CustomerSector> UpdateAsync(CustomerSector customerSector)
    {
        CustomerSector updatedCustomerSector = await _customerSectorRepository.UpdateAsync(customerSector);

        return updatedCustomerSector;
    }

    public async Task<CustomerSector> DeleteAsync(CustomerSector customerSector, bool permanent = false)
    {
        CustomerSector deletedCustomerSector = await _customerSectorRepository.DeleteAsync(customerSector);

        return deletedCustomerSector;
    }
}
