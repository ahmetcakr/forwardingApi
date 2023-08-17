using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICustomerFirmTypeRepository : IAsyncRepository<CustomerFirmType, int>, IRepository<CustomerFirmType, int>
{
}