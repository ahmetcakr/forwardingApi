using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BookingTypeRepository : EfRepositoryBase<BookingType, int, BaseDbContext>, IBookingTypeRepository
{
    public BookingTypeRepository(BaseDbContext context) : base(context)
    {
    }
}