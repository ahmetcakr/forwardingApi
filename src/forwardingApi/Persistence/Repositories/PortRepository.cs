using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PortRepository : EfRepositoryBase<Port, int, BaseDbContext>, IPortRepository
{
    public PortRepository(BaseDbContext context) : base(context)
    {
    }
}