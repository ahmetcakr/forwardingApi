using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomerSectorRepository : EfRepositoryBase<CustomerSector, int, BaseDbContext>, ICustomerSectorRepository
{
    public CustomerSectorRepository(BaseDbContext context) : base(context)
    {
    }
}