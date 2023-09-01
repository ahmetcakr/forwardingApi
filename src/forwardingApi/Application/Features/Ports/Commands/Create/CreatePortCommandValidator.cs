using FluentValidation;

namespace Application.Features.Ports.Commands.Create;

public class CreatePortCommandValidator : AbstractValidator<CreatePortCommand>
{
    public CreatePortCommandValidator()
    {
        RuleFor(c => c.PortName).NotEmpty();
        RuleFor(c => c.PortCode).NotEmpty();
        RuleFor(c => c.CountryCode).NotEmpty();
        RuleFor(c => c.CountryName).NotEmpty();
        RuleFor(c => c.Region).NotEmpty();
    }
}