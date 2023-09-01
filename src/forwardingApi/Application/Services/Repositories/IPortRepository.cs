using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPortRepository : IAsyncRepository<Port, int>, IRepository<Port, int>
{
}