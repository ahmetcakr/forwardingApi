using FluentValidation;

namespace Application.Features.Customers.Commands.Update;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerCode).NotEmpty();
        RuleFor(c => c.CustomerName).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.Region).NotEmpty();
        RuleFor(c => c.PostalCode).NotEmpty();
        RuleFor(c => c.Country).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
        RuleFor(c => c.Mail).NotEmpty();
        RuleFor(c => c.CommercialDetailId).NotEmpty();
        RuleFor(c => c.CommercialTypeId).NotEmpty();
        RuleFor(c => c.EBillId).NotEmpty();
        RuleFor(c => c.FirmTypeId).NotEmpty();
        RuleFor(c => c.GroupId).NotEmpty();
        RuleFor(c => c.SectorId).NotEmpty();
    }
}