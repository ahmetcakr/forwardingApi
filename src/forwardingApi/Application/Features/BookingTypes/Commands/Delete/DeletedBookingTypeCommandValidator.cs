using FluentValidation;

namespace Application.Features.BookingTypes.Commands.Delete;

public class DeleteBookingTypeCommandValidator : AbstractValidator<DeleteBookingTypeCommand>
{
    public DeleteBookingTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}