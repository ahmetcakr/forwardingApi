using Application.Features.Ships.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Ships.Constants.ShipsOperationClaims;

namespace Application.Features.Ships.Queries.GetList;

public class GetListShipQuery : IRequest<GetListResponse<GetListShipListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListShipQueryHandler : IRequestHandler<GetListShipQuery, GetListResponse<GetListShipListItemDto>>
    {
        private readonly IShipRepository _shipRepository;
        private readonly IMapper _mapper;

        public GetListShipQueryHandler(IShipRepository shipRepository, IMapper mapper)
        {
            _shipRepository = shipRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListShipListItemDto>> Handle(GetListShipQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Ship> ships = await _shipRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListShipListItemDto> response = _mapper.Map<GetListResponse<GetListShipListItemDto>>(ships);
            return response;
        }
    }
}