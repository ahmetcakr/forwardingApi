using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BookingRepository : EfRepositoryBase<Booking, int, BaseDbContext>, IBookingRepository
{
    public BookingRepository(BaseDbContext context) : base(context)
    {
    }
}