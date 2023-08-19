using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DetentionRepository : EfRepositoryBase<Detention, int, BaseDbContext>, IDetentionRepository
{
    public DetentionRepository(BaseDbContext context) : base(context)
    {
    }
}