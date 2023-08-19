using FluentValidation;

namespace Application.Features.Pods.Commands.Delete;

public class DeletePodCommandValidator : AbstractValidator<DeletePodCommand>
{
    public DeletePodCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}