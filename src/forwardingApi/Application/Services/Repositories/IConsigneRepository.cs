using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IConsigneRepository : IAsyncRepository<Consigne, int>, IRepository<Consigne, int>
{
}