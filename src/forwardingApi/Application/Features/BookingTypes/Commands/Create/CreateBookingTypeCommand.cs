using Application.Features.BookingTypes.Constants;
using Application.Features.BookingTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.BookingTypes.Constants.BookingTypesOperationClaims;

namespace Application.Features.BookingTypes.Commands.Create;

public class CreateBookingTypeCommand : IRequest<CreatedBookingTypeResponse>, ISecuredRequest, ITransactionalRequest
{
    public string Type { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingTypesOperationClaims.Create };

    public class CreateBookingTypeCommandHandler : IRequestHandler<CreateBookingTypeCommand, CreatedBookingTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBookingTypeRepository _bookingTypeRepository;
        private readonly BookingTypeBusinessRules _bookingTypeBusinessRules;

        public CreateBookingTypeCommandHandler(IMapper mapper, IBookingTypeRepository bookingTypeRepository,
                                         BookingTypeBusinessRules bookingTypeBusinessRules)
        {
            _mapper = mapper;
            _bookingTypeRepository = bookingTypeRepository;
            _bookingTypeBusinessRules = bookingTypeBusinessRules;
        }

        public async Task<CreatedBookingTypeResponse> Handle(CreateBookingTypeCommand request, CancellationToken cancellationToken)
        {
            BookingType bookingType = _mapper.Map<BookingType>(request);

            await _bookingTypeRepository.AddAsync(bookingType);

            CreatedBookingTypeResponse response = _mapper.Map<CreatedBookingTypeResponse>(bookingType);
            return response;
        }
    }
}