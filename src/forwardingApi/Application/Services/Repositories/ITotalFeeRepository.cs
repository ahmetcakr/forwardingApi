using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITotalFeeRepository : IAsyncRepository<TotalFee, int>, IRepository<TotalFee, int>
{
}