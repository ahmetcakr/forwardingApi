using Application.Features.CustomerCommercialDetails.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CustomerCommercialDetails.Rules;

public class CustomerCommercialDetailBusinessRules : BaseBusinessRules
{
    private readonly ICustomerCommercialDetailRepository _customerCommercialDetailRepository;

    public CustomerCommercialDetailBusinessRules(ICustomerCommercialDetailRepository customerCommercialDetailRepository)
    {
        _customerCommercialDetailRepository = customerCommercialDetailRepository;
    }

    public Task CustomerCommercialDetailShouldExistWhenSelected(CustomerCommercialDetail? customerCommercialDetail)
    {
        if (customerCommercialDetail == null)
            throw new BusinessException(CustomerCommercialDetailsBusinessMessages.CustomerCommercialDetailNotExists);
        return Task.CompletedTask;
    }

    public async Task CustomerCommercialDetailIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CustomerCommercialDetail? customerCommercialDetail = await _customerCommercialDetailRepository.GetAsync(
            predicate: ccd => ccd.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CustomerCommercialDetailShouldExistWhenSelected(customerCommercialDetail);
    }
}