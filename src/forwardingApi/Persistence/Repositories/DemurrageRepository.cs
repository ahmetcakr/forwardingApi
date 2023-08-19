using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DemurrageRepository : EfRepositoryBase<Demurrage, int, BaseDbContext>, IDemurrageRepository
{
    public DemurrageRepository(BaseDbContext context) : base(context)
    {
    }
}