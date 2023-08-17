using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICommercialTypeRepository : IAsyncRepository<CommercialType, int>, IRepository<CommercialType, int>
{
}