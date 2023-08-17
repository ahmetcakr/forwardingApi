using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CommercialTypeRepository : EfRepositoryBase<CommercialType, int, BaseDbContext>, ICommercialTypeRepository
{
    public CommercialTypeRepository(BaseDbContext context) : base(context)
    {
    }
}