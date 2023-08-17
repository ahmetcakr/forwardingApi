using Application.Features.CustomerSectors.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CustomerSectors.Rules;

public class CustomerSectorBusinessRules : BaseBusinessRules
{
    private readonly ICustomerSectorRepository _customerSectorRepository;

    public CustomerSectorBusinessRules(ICustomerSectorRepository customerSectorRepository)
    {
        _customerSectorRepository = customerSectorRepository;
    }

    public Task CustomerSectorShouldExistWhenSelected(CustomerSector? customerSector)
    {
        if (customerSector == null)
            throw new BusinessException(CustomerSectorsBusinessMessages.CustomerSectorNotExists);
        return Task.CompletedTask;
    }

    public async Task CustomerSectorIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CustomerSector? customerSector = await _customerSectorRepository.GetAsync(
            predicate: cs => cs.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CustomerSectorShouldExistWhenSelected(customerSector);
    }
}