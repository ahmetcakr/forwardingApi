using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IFirmTypeRepository : IAsyncRepository<FirmType, int>, IRepository<FirmType, int>
{
}