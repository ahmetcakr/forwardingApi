using FluentValidation;

namespace Application.Features.CommercialDetails.Commands.Create;

public class CreateCommercialDetailCommandValidator : AbstractValidator<CreateCommercialDetailCommand>
{
    public CreateCommercialDetailCommandValidator()
    {
        RuleFor(c => c.TaxOffice).NotEmpty();
        RuleFor(c => c.TaxOfficeNo).NotEmpty();
        RuleFor(c => c.Bank).NotEmpty();
        RuleFor(c => c.BankAccountNo).NotEmpty();
        RuleFor(c => c.BankDetail).NotEmpty();
    }
}