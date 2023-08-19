using Application.Features.BookingTypes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BookingTypes;

public class BookingTypesManager : IBookingTypesService
{
    private readonly IBookingTypeRepository _bookingTypeRepository;
    private readonly BookingTypeBusinessRules _bookingTypeBusinessRules;

    public BookingTypesManager(IBookingTypeRepository bookingTypeRepository, BookingTypeBusinessRules bookingTypeBusinessRules)
    {
        _bookingTypeRepository = bookingTypeRepository;
        _bookingTypeBusinessRules = bookingTypeBusinessRules;
    }

    public async Task<BookingType?> GetAsync(
        Expression<Func<BookingType, bool>> predicate,
        Func<IQueryable<BookingType>, IIncludableQueryable<BookingType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BookingType? bookingType = await _bookingTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return bookingType;
    }

    public async Task<IPaginate<BookingType>?> GetListAsync(
        Expression<Func<BookingType, bool>>? predicate = null,
        Func<IQueryable<BookingType>, IOrderedQueryable<BookingType>>? orderBy = null,
        Func<IQueryable<BookingType>, IIncludableQueryable<BookingType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BookingType> bookingTypeList = await _bookingTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bookingTypeList;
    }

    public async Task<BookingType> AddAsync(BookingType bookingType)
    {
        BookingType addedBookingType = await _bookingTypeRepository.AddAsync(bookingType);

        return addedBookingType;
    }

    public async Task<BookingType> UpdateAsync(BookingType bookingType)
    {
        BookingType updatedBookingType = await _bookingTypeRepository.UpdateAsync(bookingType);

        return updatedBookingType;
    }

    public async Task<BookingType> DeleteAsync(BookingType bookingType, bool permanent = false)
    {
        BookingType deletedBookingType = await _bookingTypeRepository.DeleteAsync(bookingType);

        return deletedBookingType;
    }
}
