using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ConsigneRepository : EfRepositoryBase<Consigne, int, BaseDbContext>, IConsigneRepository
{
    public ConsigneRepository(BaseDbContext context) : base(context)
    {
    }
}