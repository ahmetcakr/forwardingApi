using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICommercialDetailRepository : IAsyncRepository<CommercialDetail, int>, IRepository<CommercialDetail, int>
{
}