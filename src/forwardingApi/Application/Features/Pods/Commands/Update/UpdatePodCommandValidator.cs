using FluentValidation;

namespace Application.Features.Pods.Commands.Update;

public class UpdatePodCommandValidator : AbstractValidator<UpdatePodCommand>
{
    public UpdatePodCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PodName).NotEmpty();
    }
}