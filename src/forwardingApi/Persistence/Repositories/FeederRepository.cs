using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FeederRepository : EfRepositoryBase<Feeder, int, BaseDbContext>, IFeederRepository
{
    public FeederRepository(BaseDbContext context) : base(context)
    {
    }
}