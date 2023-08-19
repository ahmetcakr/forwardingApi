using Application.Features.Ships.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Ships.Rules;

public class ShipBusinessRules : BaseBusinessRules
{
    private readonly IShipRepository _shipRepository;

    public ShipBusinessRules(IShipRepository shipRepository)
    {
        _shipRepository = shipRepository;
    }

    public Task ShipShouldExistWhenSelected(Ship? ship)
    {
        if (ship == null)
            throw new BusinessException(ShipsBusinessMessages.ShipNotExists);
        return Task.CompletedTask;
    }

    public async Task ShipIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Ship? ship = await _shipRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ShipShouldExistWhenSelected(ship);
    }
}