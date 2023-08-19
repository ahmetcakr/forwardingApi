using FluentValidation;

namespace Application.Features.Bookings.Commands.Create;

public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
{
    public CreateBookingCommandValidator()
    {
        RuleFor(c => c.CompanyId).NotEmpty();
        RuleFor(c => c.MBLNo).NotEmpty();
        RuleFor(c => c.ProjectNo).NotEmpty();
        RuleFor(c => c.Etd).NotEmpty();
        RuleFor(c => c.Eta).NotEmpty();
        RuleFor(c => c.DeclarationNo).NotEmpty();
        RuleFor(c => c.DeclarationDate).NotEmpty();
        RuleFor(c => c.OrdinoDate).NotEmpty();
        RuleFor(c => c.Region).NotEmpty();
        RuleFor(c => c.Agent).NotEmpty();
        RuleFor(c => c.Note).NotEmpty();
        RuleFor(c => c.IsOrigin).NotEmpty();
        RuleFor(c => c.IsCopy).NotEmpty();
        RuleFor(c => c.FileNo).NotEmpty();
        RuleFor(c => c.BookingTypeID).NotEmpty();
        RuleFor(c => c.PolID).NotEmpty();
        RuleFor(c => c.PodID).NotEmpty();
        RuleFor(c => c.RouteID).NotEmpty();
        RuleFor(c => c.ShipID).NotEmpty();
        RuleFor(c => c.ShipVoyageID).NotEmpty();
        RuleFor(c => c.FeederID).NotEmpty();
        RuleFor(c => c.FeederVoyageID).NotEmpty();
        RuleFor(c => c.ShipperID).NotEmpty();
        RuleFor(c => c.ConsigneID).NotEmpty();
        RuleFor(c => c.NotifyID).NotEmpty();
        RuleFor(c => c.ApplyToID).NotEmpty();
        RuleFor(c => c.OperationResponsibleID).NotEmpty();
        RuleFor(c => c.MarketingResponsibleID).NotEmpty();
        RuleFor(c => c.DemurrageID).NotEmpty();
        RuleFor(c => c.DetentionID).NotEmpty();
        RuleFor(c => c.FreeDayID).NotEmpty();
        RuleFor(c => c.TotalFeeID).NotEmpty();
    }
}