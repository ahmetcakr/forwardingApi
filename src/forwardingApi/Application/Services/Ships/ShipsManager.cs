using Application.Features.Ships.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Ships;

public class ShipsManager : IShipsService
{
    private readonly IShipRepository _shipRepository;
    private readonly ShipBusinessRules _shipBusinessRules;

    public ShipsManager(IShipRepository shipRepository, ShipBusinessRules shipBusinessRules)
    {
        _shipRepository = shipRepository;
        _shipBusinessRules = shipBusinessRules;
    }

    public async Task<Ship?> GetAsync(
        Expression<Func<Ship, bool>> predicate,
        Func<IQueryable<Ship>, IIncludableQueryable<Ship, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Ship? ship = await _shipRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return ship;
    }

    public async Task<IPaginate<Ship>?> GetListAsync(
        Expression<Func<Ship, bool>>? predicate = null,
        Func<IQueryable<Ship>, IOrderedQueryable<Ship>>? orderBy = null,
        Func<IQueryable<Ship>, IIncludableQueryable<Ship, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Ship> shipList = await _shipRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return shipList;
    }

    public async Task<Ship> AddAsync(Ship ship)
    {
        Ship addedShip = await _shipRepository.AddAsync(ship);

        return addedShip;
    }

    public async Task<Ship> UpdateAsync(Ship ship)
    {
        Ship updatedShip = await _shipRepository.UpdateAsync(ship);

        return updatedShip;
    }

    public async Task<Ship> DeleteAsync(Ship ship, bool permanent = false)
    {
        Ship deletedShip = await _shipRepository.DeleteAsync(ship);

        return deletedShip;
    }
}
