using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BookingTypes;

public interface IBookingTypesService
{
    Task<BookingType?> GetAsync(
        Expression<Func<BookingType, bool>> predicate,
        Func<IQueryable<BookingType>, IIncludableQueryable<BookingType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BookingType>?> GetListAsync(
        Expression<Func<BookingType, bool>>? predicate = null,
        Func<IQueryable<BookingType>, IOrderedQueryable<BookingType>>? orderBy = null,
        Func<IQueryable<BookingType>, IIncludableQueryable<BookingType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BookingType> AddAsync(BookingType bookingType);
    Task<BookingType> UpdateAsync(BookingType bookingType);
    Task<BookingType> DeleteAsync(BookingType bookingType, bool permanent = false);
}
