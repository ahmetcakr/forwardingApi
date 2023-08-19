using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBookingRepository : IAsyncRepository<Booking, int>, IRepository<Booking, int>
{
}