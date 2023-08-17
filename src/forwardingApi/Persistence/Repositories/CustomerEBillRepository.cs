using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomerEBillRepository : EfRepositoryBase<CustomerEBill, int, BaseDbContext>, ICustomerEBillRepository
{
    public CustomerEBillRepository(BaseDbContext context) : base(context)
    {
    }
}