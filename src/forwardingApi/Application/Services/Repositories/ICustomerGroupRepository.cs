using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICustomerGroupRepository : IAsyncRepository<CustomerGroup, int>, IRepository<CustomerGroup, int>
{
}