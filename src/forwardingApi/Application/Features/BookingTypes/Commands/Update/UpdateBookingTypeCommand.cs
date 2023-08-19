using Application.Features.BookingTypes.Constants;
using Application.Features.BookingTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.BookingTypes.Constants.BookingTypesOperationClaims;

namespace Application.Features.BookingTypes.Commands.Update;

public class UpdateBookingTypeCommand : IRequest<UpdatedBookingTypeResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingTypesOperationClaims.Update };

    public class UpdateBookingTypeCommandHandler : IRequestHandler<UpdateBookingTypeCommand, UpdatedBookingTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBookingTypeRepository _bookingTypeRepository;
        private readonly BookingTypeBusinessRules _bookingTypeBusinessRules;

        public UpdateBookingTypeCommandHandler(IMapper mapper, IBookingTypeRepository bookingTypeRepository,
                                         BookingTypeBusinessRules bookingTypeBusinessRules)
        {
            _mapper = mapper;
            _bookingTypeRepository = bookingTypeRepository;
            _bookingTypeBusinessRules = bookingTypeBusinessRules;
        }

        public async Task<UpdatedBookingTypeResponse> Handle(UpdateBookingTypeCommand request, CancellationToken cancellationToken)
        {
            BookingType? bookingType = await _bookingTypeRepository.GetAsync(predicate: bt => bt.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingTypeBusinessRules.BookingTypeShouldExistWhenSelected(bookingType);
            bookingType = _mapper.Map(request, bookingType);

            await _bookingTypeRepository.UpdateAsync(bookingType!);

            UpdatedBookingTypeResponse response = _mapper.Map<UpdatedBookingTypeResponse>(bookingType);
            return response;
        }
    }
}