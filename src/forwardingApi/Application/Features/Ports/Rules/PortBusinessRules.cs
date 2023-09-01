using Application.Features.Ports.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Ports.Rules;

public class PortBusinessRules : BaseBusinessRules
{
    private readonly IPortRepository _portRepository;

    public PortBusinessRules(IPortRepository portRepository)
    {
        _portRepository = portRepository;
    }

    public Task PortShouldExistWhenSelected(Port? port)
    {
        if (port == null)
            throw new BusinessException(PortsBusinessMessages.PortNotExists);
        return Task.CompletedTask;
    }

    public async Task PortIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Port? port = await _portRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PortShouldExistWhenSelected(port);
    }
}