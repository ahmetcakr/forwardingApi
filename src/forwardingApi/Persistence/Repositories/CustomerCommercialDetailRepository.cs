using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomerCommercialDetailRepository : EfRepositoryBase<CustomerCommercialDetail, int, BaseDbContext>, ICustomerCommercialDetailRepository
{
    public CustomerCommercialDetailRepository(BaseDbContext context) : base(context)
    {
    }
}