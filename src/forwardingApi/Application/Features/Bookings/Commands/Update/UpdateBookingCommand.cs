using Application.Features.Bookings.Constants;
using Application.Features.Bookings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Bookings.Constants.BookingsOperationClaims;

namespace Application.Features.Bookings.Commands.Update;

public class UpdateBookingCommand : IRequest<UpdatedBookingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string? MBLNo { get; set; }
    public string? ProjectNo { get; set; }
    public DateTime? Etd { get; set; }
    public DateTime? Eta { get; set; }
    public string? DeclarationNo { get; set; }
    public DateTime? DeclarationDate { get; set; }
    public DateTime? OrdinoDate { get; set; }
    public string? Region { get; set; }
    public string? Agent { get; set; }
    public string? Note { get; set; }
    public string? IsOrigin { get; set; }
    public string? IsCopy { get; set; }
    public string? FileNo { get; set; }
    public int BookingTypeID { get; set; }
    public int PolID { get; set; }
    public int PodID { get; set; }
    public int? RouteID { get; set; }
    public int ShipID { get; set; }
    public int? ShipVoyageID { get; set; }
    public int FeederID { get; set; }
    public int FeederVoyageID { get; set; }
    public int ShipperID { get; set; }
    public int? ConsigneID { get; set; }
    public int? NotifyID { get; set; }
    public int ApplyToID { get; set; }
    public int? OperationResponsibleID { get; set; }
    public int? MarketingResponsibleID { get; set; }
    public int? DemurrageID { get; set; }
    public int? DetentionID { get; set; }
    public int? FreeDayID { get; set; }
    public int? TotalFeeID { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetBookings";

    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, UpdatedBookingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;
        private readonly BookingBusinessRules _bookingBusinessRules;

        public UpdateBookingCommandHandler(IMapper mapper, IBookingRepository bookingRepository,
                                         BookingBusinessRules bookingBusinessRules)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
            _bookingBusinessRules = bookingBusinessRules;
        }

        public async Task<UpdatedBookingResponse> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            Booking? booking = await _bookingRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingBusinessRules.BookingShouldExistWhenSelected(booking);
            booking = _mapper.Map(request, booking);

            await _bookingRepository.UpdateAsync(booking!);

            UpdatedBookingResponse response = _mapper.Map<UpdatedBookingResponse>(booking);
            return response;
        }
    }
}