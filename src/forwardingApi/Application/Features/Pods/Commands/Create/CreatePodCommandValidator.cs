using FluentValidation;

namespace Application.Features.Pods.Commands.Create;

public class CreatePodCommandValidator : AbstractValidator<CreatePodCommand>
{
    public CreatePodCommandValidator()
    {
        RuleFor(c => c.PodName).NotEmpty();
    }
}