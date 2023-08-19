using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TotalFeeRepository : EfRepositoryBase<TotalFee, int, BaseDbContext>, ITotalFeeRepository
{
    public TotalFeeRepository(BaseDbContext context) : base(context)
    {
    }
}