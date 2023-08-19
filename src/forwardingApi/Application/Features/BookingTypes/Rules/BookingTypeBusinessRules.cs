using Application.Features.BookingTypes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.BookingTypes.Rules;

public class BookingTypeBusinessRules : BaseBusinessRules
{
    private readonly IBookingTypeRepository _bookingTypeRepository;

    public BookingTypeBusinessRules(IBookingTypeRepository bookingTypeRepository)
    {
        _bookingTypeRepository = bookingTypeRepository;
    }

    public Task BookingTypeShouldExistWhenSelected(BookingType? bookingType)
    {
        if (bookingType == null)
            throw new BusinessException(BookingTypesBusinessMessages.BookingTypeNotExists);
        return Task.CompletedTask;
    }

    public async Task BookingTypeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        BookingType? bookingType = await _bookingTypeRepository.GetAsync(
            predicate: bt => bt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BookingTypeShouldExistWhenSelected(bookingType);
    }
}