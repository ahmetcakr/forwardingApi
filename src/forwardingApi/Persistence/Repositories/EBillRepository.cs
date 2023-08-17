using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EBillRepository : EfRepositoryBase<EBill, int, BaseDbContext>, IEBillRepository
{
    public EBillRepository(BaseDbContext context) : base(context)
    {
    }
}