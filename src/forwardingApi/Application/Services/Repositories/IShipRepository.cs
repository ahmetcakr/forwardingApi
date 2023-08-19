using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IShipRepository : IAsyncRepository<Ship, int>, IRepository<Ship, int>
{
}