using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICustomerSectorRepository : IAsyncRepository<CustomerSector, int>, IRepository<CustomerSector, int>
{
}