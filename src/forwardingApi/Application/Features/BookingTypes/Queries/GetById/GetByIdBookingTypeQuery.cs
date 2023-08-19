using Application.Features.BookingTypes.Constants;
using Application.Features.BookingTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BookingTypes.Constants.BookingTypesOperationClaims;

namespace Application.Features.BookingTypes.Queries.GetById;

public class GetByIdBookingTypeQuery : IRequest<GetByIdBookingTypeResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdBookingTypeQueryHandler : IRequestHandler<GetByIdBookingTypeQuery, GetByIdBookingTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBookingTypeRepository _bookingTypeRepository;
        private readonly BookingTypeBusinessRules _bookingTypeBusinessRules;

        public GetByIdBookingTypeQueryHandler(IMapper mapper, IBookingTypeRepository bookingTypeRepository, BookingTypeBusinessRules bookingTypeBusinessRules)
        {
            _mapper = mapper;
            _bookingTypeRepository = bookingTypeRepository;
            _bookingTypeBusinessRules = bookingTypeBusinessRules;
        }

        public async Task<GetByIdBookingTypeResponse> Handle(GetByIdBookingTypeQuery request, CancellationToken cancellationToken)
        {
            BookingType? bookingType = await _bookingTypeRepository.GetAsync(predicate: bt => bt.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingTypeBusinessRules.BookingTypeShouldExistWhenSelected(bookingType);

            GetByIdBookingTypeResponse response = _mapper.Map<GetByIdBookingTypeResponse>(bookingType);
            return response;
        }
    }
}