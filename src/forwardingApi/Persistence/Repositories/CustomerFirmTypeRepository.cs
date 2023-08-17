using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomerFirmTypeRepository : EfRepositoryBase<CustomerFirmType, int, BaseDbContext>, ICustomerFirmTypeRepository
{
    public CustomerFirmTypeRepository(BaseDbContext context) : base(context)
    {
    }
}