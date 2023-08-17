using Application.Features.CustomerEBills.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CustomerEBills.Rules;

public class CustomerEBillBusinessRules : BaseBusinessRules
{
    private readonly ICustomerEBillRepository _customerEBillRepository;

    public CustomerEBillBusinessRules(ICustomerEBillRepository customerEBillRepository)
    {
        _customerEBillRepository = customerEBillRepository;
    }

    public Task CustomerEBillShouldExistWhenSelected(CustomerEBill? customerEBill)
    {
        if (customerEBill == null)
            throw new BusinessException(CustomerEBillsBusinessMessages.CustomerEBillNotExists);
        return Task.CompletedTask;
    }

    public async Task CustomerEBillIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CustomerEBill? customerEBill = await _customerEBillRepository.GetAsync(
            predicate: ceb => ceb.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CustomerEBillShouldExistWhenSelected(customerEBill);
    }
}