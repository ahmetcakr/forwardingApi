using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDetentionRepository : IAsyncRepository<Detention, int>, IRepository<Detention, int>
{
}