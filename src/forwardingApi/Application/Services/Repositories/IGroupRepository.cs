using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IGroupRepository : IAsyncRepository<Group, int>, IRepository<Group, int>
{
}