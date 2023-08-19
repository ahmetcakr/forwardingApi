using FluentValidation;

namespace Application.Features.BookingTypes.Commands.Create;

public class CreateBookingTypeCommandValidator : AbstractValidator<CreateBookingTypeCommand>
{
    public CreateBookingTypeCommandValidator()
    {
        RuleFor(c => c.Type).NotEmpty();
    }
}