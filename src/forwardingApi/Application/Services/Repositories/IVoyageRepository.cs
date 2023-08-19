using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IVoyageRepository : IAsyncRepository<Voyage, int>, IRepository<Voyage, int>
{
}