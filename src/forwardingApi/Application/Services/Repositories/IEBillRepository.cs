using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IEBillRepository : IAsyncRepository<EBill, int>, IRepository<EBill, int>
{
}