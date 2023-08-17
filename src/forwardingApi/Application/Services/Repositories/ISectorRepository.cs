using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISectorRepository : IAsyncRepository<Sector, int>, IRepository<Sector, int>
{
}