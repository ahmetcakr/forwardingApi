using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDemurrageRepository : IAsyncRepository<Demurrage, int>, IRepository<Demurrage, int>
{
}