using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRouteRepository : IAsyncRepository<Route, int>, IRepository<Route, int>
{
}