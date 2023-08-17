using FluentValidation;

namespace Application.Features.CommercialDetails.Commands.Update;

public class UpdateCommercialDetailCommandValidator : AbstractValidator<UpdateCommercialDetailCommand>
{
    public UpdateCommercialDetailCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TaxOffice).NotEmpty();
        RuleFor(c => c.TaxOfficeNo).NotEmpty();
        RuleFor(c => c.Bank).NotEmpty();
        RuleFor(c => c.BankAccountNo).NotEmpty();
        RuleFor(c => c.BankDetail).NotEmpty();
    }
}