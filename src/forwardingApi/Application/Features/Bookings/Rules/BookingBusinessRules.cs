using Application.Features.Bookings.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Bookings.Rules;

public class BookingBusinessRules : BaseBusinessRules
{
    private readonly IBookingRepository _bookingRepository;

    public BookingBusinessRules(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public Task BookingShouldExistWhenSelected(Booking? booking)
    {
        if (booking == null)
            throw new BusinessException(BookingsBusinessMessages.BookingNotExists);
        return Task.CompletedTask;
    }

    public async Task BookingIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Booking? booking = await _bookingRepository.GetAsync(
            predicate: b => b.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BookingShouldExistWhenSelected(booking);
    }
}