using Application.Features.CustomerCommercialDetails.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerCommercialDetails;

public class CustomerCommercialDetailsManager : ICustomerCommercialDetailsService
{
    private readonly ICustomerCommercialDetailRepository _customerCommercialDetailRepository;
    private readonly CustomerCommercialDetailBusinessRules _customerCommercialDetailBusinessRules;

    public CustomerCommercialDetailsManager(ICustomerCommercialDetailRepository customerCommercialDetailRepository, CustomerCommercialDetailBusinessRules customerCommercialDetailBusinessRules)
    {
        _customerCommercialDetailRepository = customerCommercialDetailRepository;
        _customerCommercialDetailBusinessRules = customerCommercialDetailBusinessRules;
    }

    public async Task<CustomerCommercialDetail?> GetAsync(
        Expression<Func<CustomerCommercialDetail, bool>> predicate,
        Func<IQueryable<CustomerCommercialDetail>, IIncludableQueryable<CustomerCommercialDetail, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CustomerCommercialDetail? customerCommercialDetail = await _customerCommercialDetailRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return customerCommercialDetail;
    }

    public async Task<IPaginate<CustomerCommercialDetail>?> GetListAsync(
        Expression<Func<CustomerCommercialDetail, bool>>? predicate = null,
        Func<IQueryable<CustomerCommercialDetail>, IOrderedQueryable<CustomerCommercialDetail>>? orderBy = null,
        Func<IQueryable<CustomerCommercialDetail>, IIncludableQueryable<CustomerCommercialDetail, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CustomerCommercialDetail> customerCommercialDetailList = await _customerCommercialDetailRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return customerCommercialDetailList;
    }

    public async Task<CustomerCommercialDetail> AddAsync(CustomerCommercialDetail customerCommercialDetail)
    {
        CustomerCommercialDetail addedCustomerCommercialDetail = await _customerCommercialDetailRepository.AddAsync(customerCommercialDetail);

        return addedCustomerCommercialDetail;
    }

    public async Task<CustomerCommercialDetail> UpdateAsync(CustomerCommercialDetail customerCommercialDetail)
    {
        CustomerCommercialDetail updatedCustomerCommercialDetail = await _customerCommercialDetailRepository.UpdateAsync(customerCommercialDetail);

        return updatedCustomerCommercialDetail;
    }

    public async Task<CustomerCommercialDetail> DeleteAsync(CustomerCommercialDetail customerCommercialDetail, bool permanent = false)
    {
        CustomerCommercialDetail deletedCustomerCommercialDetail = await _customerCommercialDetailRepository.DeleteAsync(customerCommercialDetail);

        return deletedCustomerCommercialDetail;
    }
}
