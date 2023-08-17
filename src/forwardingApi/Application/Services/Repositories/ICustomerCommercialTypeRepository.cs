using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICustomerCommercialTypeRepository : IAsyncRepository<CustomerCommercialType, int>, IRepository<CustomerCommercialType, int>
{
}