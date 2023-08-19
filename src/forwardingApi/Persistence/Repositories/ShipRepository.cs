using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ShipRepository : EfRepositoryBase<Ship, int, BaseDbContext>, IShipRepository
{
    public ShipRepository(BaseDbContext context) : base(context)
    {
    }
}