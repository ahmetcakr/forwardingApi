using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICustomerEBillRepository : IAsyncRepository<CustomerEBill, int>, IRepository<CustomerEBill, int>
{
}