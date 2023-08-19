using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RouteRepository : EfRepositoryBase<Route, int, BaseDbContext>, IRouteRepository
{
    public RouteRepository(BaseDbContext context) : base(context)
    {
    }
}