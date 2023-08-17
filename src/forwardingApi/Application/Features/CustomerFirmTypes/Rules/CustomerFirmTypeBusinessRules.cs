using Application.Features.CustomerFirmTypes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CustomerFirmTypes.Rules;

public class CustomerFirmTypeBusinessRules : BaseBusinessRules
{
    private readonly ICustomerFirmTypeRepository _customerFirmTypeRepository;

    public CustomerFirmTypeBusinessRules(ICustomerFirmTypeRepository customerFirmTypeRepository)
    {
        _customerFirmTypeRepository = customerFirmTypeRepository;
    }

    public Task CustomerFirmTypeShouldExistWhenSelected(CustomerFirmType? customerFirmType)
    {
        if (customerFirmType == null)
            throw new BusinessException(CustomerFirmTypesBusinessMessages.CustomerFirmTypeNotExists);
        return Task.CompletedTask;
    }

    public async Task CustomerFirmTypeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CustomerFirmType? customerFirmType = await _customerFirmTypeRepository.GetAsync(
            predicate: cft => cft.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CustomerFirmTypeShouldExistWhenSelected(customerFirmType);
    }
}