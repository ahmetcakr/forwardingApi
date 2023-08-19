using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PodRepository : EfRepositoryBase<Pod, int, BaseDbContext>, IPodRepository
{
    public PodRepository(BaseDbContext context) : base(context)
    {
    }
}