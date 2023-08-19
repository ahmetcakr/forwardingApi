using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FreeDayRepository : EfRepositoryBase<FreeDay, int, BaseDbContext>, IFreeDayRepository
{
    public FreeDayRepository(BaseDbContext context) : base(context)
    {
    }
}