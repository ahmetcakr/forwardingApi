using Application.Features.CustomerCommercialTypes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CustomerCommercialTypes.Rules;

public class CustomerCommercialTypeBusinessRules : BaseBusinessRules
{
    private readonly ICustomerCommercialTypeRepository _customerCommercialTypeRepository;

    public CustomerCommercialTypeBusinessRules(ICustomerCommercialTypeRepository customerCommercialTypeRepository)
    {
        _customerCommercialTypeRepository = customerCommercialTypeRepository;
    }

    public Task CustomerCommercialTypeShouldExistWhenSelected(CustomerCommercialType? customerCommercialType)
    {
        if (customerCommercialType == null)
            throw new BusinessException(CustomerCommercialTypesBusinessMessages.CustomerCommercialTypeNotExists);
        return Task.CompletedTask;
    }

    public async Task CustomerCommercialTypeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CustomerCommercialType? customerCommercialType = await _customerCommercialTypeRepository.GetAsync(
            predicate: cct => cct.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CustomerCommercialTypeShouldExistWhenSelected(customerCommercialType);
    }
}