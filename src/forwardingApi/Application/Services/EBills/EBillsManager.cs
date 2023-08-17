using Application.Features.EBills.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EBills;

public class EBillsManager : IEBillsService
{
    private readonly IEBillRepository _eBillRepository;
    private readonly EBillBusinessRules _eBillBusinessRules;

    public EBillsManager(IEBillRepository eBillRepository, EBillBusinessRules eBillBusinessRules)
    {
        _eBillRepository = eBillRepository;
        _eBillBusinessRules = eBillBusinessRules;
    }

    public async Task<EBill?> GetAsync(
        Expression<Func<EBill, bool>> predicate,
        Func<IQueryable<EBill>, IIncludableQueryable<EBill, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        EBill? eBill = await _eBillRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return eBill;
    }

    public async Task<IPaginate<EBill>?> GetListAsync(
        Expression<Func<EBill, bool>>? predicate = null,
        Func<IQueryable<EBill>, IOrderedQueryable<EBill>>? orderBy = null,
        Func<IQueryable<EBill>, IIncludableQueryable<EBill, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<EBill> eBillList = await _eBillRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return eBillList;
    }

    public async Task<EBill> AddAsync(EBill eBill)
    {
        EBill addedEBill = await _eBillRepository.AddAsync(eBill);

        return addedEBill;
    }

    public async Task<EBill> UpdateAsync(EBill eBill)
    {
        EBill updatedEBill = await _eBillRepository.UpdateAsync(eBill);

        return updatedEBill;
    }

    public async Task<EBill> DeleteAsync(EBill eBill, bool permanent = false)
    {
        EBill deletedEBill = await _eBillRepository.DeleteAsync(eBill);

        return deletedEBill;
    }
}
