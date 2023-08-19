using FluentValidation;

namespace Application.Features.BookingTypes.Commands.Update;

public class UpdateBookingTypeCommandValidator : AbstractValidator<UpdateBookingTypeCommand>
{
    public UpdateBookingTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}