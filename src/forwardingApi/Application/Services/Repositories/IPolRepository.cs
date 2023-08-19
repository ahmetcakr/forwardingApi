using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPolRepository : IAsyncRepository<Pol, int>, IRepository<Pol, int>
{
}