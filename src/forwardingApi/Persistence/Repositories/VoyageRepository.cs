using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class VoyageRepository : EfRepositoryBase<Voyage, int, BaseDbContext>, IVoyageRepository
{
    public VoyageRepository(BaseDbContext context) : base(context)
    {
    }
}