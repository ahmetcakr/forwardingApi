using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PolRepository : EfRepositoryBase<Pol, int, BaseDbContext>, IPolRepository
{
    public PolRepository(BaseDbContext context) : base(context)
    {
    }
}