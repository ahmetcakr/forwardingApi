using FluentValidation;

namespace Application.Features.Ports.Commands.Update;

public class UpdatePortCommandValidator : AbstractValidator<UpdatePortCommand>
{
    public UpdatePortCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PortName).NotEmpty();
        RuleFor(c => c.PortCode).NotEmpty();
        RuleFor(c => c.CountryCode).NotEmpty();
        RuleFor(c => c.CountryName).NotEmpty();
        RuleFor(c => c.Region).NotEmpty();
    }
}