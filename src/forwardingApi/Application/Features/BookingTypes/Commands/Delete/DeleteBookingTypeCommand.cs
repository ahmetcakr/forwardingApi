using Application.Features.BookingTypes.Constants;
using Application.Features.BookingTypes.Constants;
using Application.Features.BookingTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.BookingTypes.Constants.BookingTypesOperationClaims;

namespace Application.Features.BookingTypes.Commands.Delete;

public class DeleteBookingTypeCommand : IRequest<DeletedBookingTypeResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingTypesOperationClaims.Delete };

    public class DeleteBookingTypeCommandHandler : IRequestHandler<DeleteBookingTypeCommand, DeletedBookingTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBookingTypeRepository _bookingTypeRepository;
        private readonly BookingTypeBusinessRules _bookingTypeBusinessRules;

        public DeleteBookingTypeCommandHandler(IMapper mapper, IBookingTypeRepository bookingTypeRepository,
                                         BookingTypeBusinessRules bookingTypeBusinessRules)
        {
            _mapper = mapper;
            _bookingTypeRepository = bookingTypeRepository;
            _bookingTypeBusinessRules = bookingTypeBusinessRules;
        }

        public async Task<DeletedBookingTypeResponse> Handle(DeleteBookingTypeCommand request, CancellationToken cancellationToken)
        {
            BookingType? bookingType = await _bookingTypeRepository.GetAsync(predicate: bt => bt.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingTypeBusinessRules.BookingTypeShouldExistWhenSelected(bookingType);

            await _bookingTypeRepository.DeleteAsync(bookingType!);

            DeletedBookingTypeResponse response = _mapper.Map<DeletedBookingTypeResponse>(bookingType);
            return response;
        }
    }
}