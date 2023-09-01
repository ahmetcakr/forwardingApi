using FluentValidation;

namespace Application.Features.Ports.Commands.Delete;

public class DeletePortCommandValidator : AbstractValidator<DeletePortCommand>
{
    public DeletePortCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}