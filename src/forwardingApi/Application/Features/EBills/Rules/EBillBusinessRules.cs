using Application.Features.EBills.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.EBills.Rules;

public class EBillBusinessRules : BaseBusinessRules
{
    private readonly IEBillRepository _eBillRepository;

    public EBillBusinessRules(IEBillRepository eBillRepository)
    {
        _eBillRepository = eBillRepository;
    }

    public Task EBillShouldExistWhenSelected(EBill? eBill)
    {
        if (eBill == null)
            throw new BusinessException(EBillsBusinessMessages.EBillNotExists);
        return Task.CompletedTask;
    }

    public async Task EBillIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        EBill? eBill = await _eBillRepository.GetAsync(
            predicate: eb => eb.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EBillShouldExistWhenSelected(eBill);
    }
}