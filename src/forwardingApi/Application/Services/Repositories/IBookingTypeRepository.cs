using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBookingTypeRepository : IAsyncRepository<BookingType, int>, IRepository<BookingType, int>
{
}