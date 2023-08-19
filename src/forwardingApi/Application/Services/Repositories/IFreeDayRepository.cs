using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IFreeDayRepository : IAsyncRepository<FreeDay, int>, IRepository<FreeDay, int>
{
}