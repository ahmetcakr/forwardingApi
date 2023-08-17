using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomerCommercialTypeRepository : EfRepositoryBase<CustomerCommercialType, int, BaseDbContext>, ICustomerCommercialTypeRepository
{
    public CustomerCommercialTypeRepository(BaseDbContext context) : base(context)
    {
    }
}