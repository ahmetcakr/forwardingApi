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

namespace Application.Features.Bookings.Commands.Create;

public class CreateBookingCommand : IRequest<CreatedBookingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
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

    public string[] Roles => new[] { Admin, Write, BookingsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetBookings";

    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, CreatedBookingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;
        private readonly BookingBusinessRules _bookingBusinessRules;

        public CreateBookingCommandHandler(IMapper mapper, IBookingRepository bookingRepository,
                                         BookingBusinessRules bookingBusinessRules)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
            _bookingBusinessRules = bookingBusinessRules;
        }

        public async Task<CreatedBookingResponse> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            Booking booking = _mapper.Map<Booking>(request);

            await _bookingRepository.AddAsync(booking);

            CreatedBookingResponse response = _mapper.Map<CreatedBookingResponse>(booking);
            return response;
        }
    }
}