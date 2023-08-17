using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FirmTypeRepository : EfRepositoryBase<FirmType, int, BaseDbContext>, IFirmTypeRepository
{
    public FirmTypeRepository(BaseDbContext context) : base(context)
    {
    }
}