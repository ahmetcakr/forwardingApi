using Application.Features.CustomerEBills.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerEBills;

public class CustomerEBillsManager : ICustomerEBillsService
{
    private readonly ICustomerEBillRepository _customerEBillRepository;
    private readonly CustomerEBillBusinessRules _customerEBillBusinessRules;

    public CustomerEBillsManager(ICustomerEBillRepository customerEBillRepository, CustomerEBillBusinessRules customerEBillBusinessRules)
    {
        _customerEBillRepository = customerEBillRepository;
        _customerEBillBusinessRules = customerEBillBusinessRules;
    }

    public async Task<CustomerEBill?> GetAsync(
        Expression<Func<CustomerEBill, bool>> predicate,
        Func<IQueryable<CustomerEBill>, IIncludableQueryable<CustomerEBill, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CustomerEBill? customerEBill = await _customerEBillRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return customerEBill;
    }

    public async Task<IPaginate<CustomerEBill>?> GetListAsync(
        Expression<Func<CustomerEBill, bool>>? predicate = null,
        Func<IQueryable<CustomerEBill>, IOrderedQueryable<CustomerEBill>>? orderBy = null,
        Func<IQueryable<CustomerEBill>, IIncludableQueryable<CustomerEBill, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CustomerEBill> customerEBillList = await _customerEBillRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return customerEBillList;
    }

    public async Task<CustomerEBill> AddAsync(CustomerEBill customerEBill)
    {
        CustomerEBill addedCustomerEBill = await _customerEBillRepository.AddAsync(customerEBill);

        return addedCustomerEBill;
    }

    public async Task<CustomerEBill> UpdateAsync(CustomerEBill customerEBill)
    {
        CustomerEBill updatedCustomerEBill = await _customerEBillRepository.UpdateAsync(customerEBill);

        return updatedCustomerEBill;
    }

    public async Task<CustomerEBill> DeleteAsync(CustomerEBill customerEBill, bool permanent = false)
    {
        CustomerEBill deletedCustomerEBill = await _customerEBillRepository.DeleteAsync(customerEBill);

        return deletedCustomerEBill;
    }
}
