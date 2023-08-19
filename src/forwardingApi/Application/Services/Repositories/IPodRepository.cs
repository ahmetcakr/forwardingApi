using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPodRepository : IAsyncRepository<Pod, int>, IRepository<Pod, int>
{
}