using Application.Features.BookingTypes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.BookingTypes.Constants.BookingTypesOperationClaims;

namespace Application.Features.BookingTypes.Queries.GetList;

public class GetListBookingTypeQuery : IRequest<GetListResponse<GetListBookingTypeListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListBookingTypeQueryHandler : IRequestHandler<GetListBookingTypeQuery, GetListResponse<GetListBookingTypeListItemDto>>
    {
        private readonly IBookingTypeRepository _bookingTypeRepository;
        private readonly IMapper _mapper;

        public GetListBookingTypeQueryHandler(IBookingTypeRepository bookingTypeRepository, IMapper mapper)
        {
            _bookingTypeRepository = bookingTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBookingTypeListItemDto>> Handle(GetListBookingTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BookingType> bookingTypes = await _bookingTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBookingTypeListItemDto> response = _mapper.Map<GetListResponse<GetListBookingTypeListItemDto>>(bookingTypes);
            return response;
        }
    }
}