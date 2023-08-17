using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CommercialDetailRepository : EfRepositoryBase<CommercialDetail, int, BaseDbContext>, ICommercialDetailRepository
{
    public CommercialDetailRepository(BaseDbContext context) : base(context)
    {
    }
}