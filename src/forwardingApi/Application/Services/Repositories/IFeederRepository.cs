using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IFeederRepository : IAsyncRepository<Feeder, int>, IRepository<Feeder, int>
{
}