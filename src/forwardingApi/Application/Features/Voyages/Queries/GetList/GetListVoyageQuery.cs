using Application.Features.Voyages.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Voyages.Constants.VoyagesOperationClaims;

namespace Application.Features.Voyages.Queries.GetList;

public class GetListVoyageQuery : IRequest<GetListResponse<GetListVoyageListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListVoyageQueryHandler : IRequestHandler<GetListVoyageQuery, GetListResponse<GetListVoyageListItemDto>>
    {
        private readonly IVoyageRepository _voyageRepository;
        private readonly IMapper _mapper;

        public GetListVoyageQueryHandler(IVoyageRepository voyageRepository, IMapper mapper)
        {
            _voyageRepository = voyageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListVoyageListItemDto>> Handle(GetListVoyageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Voyage> voyages = await _voyageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListVoyageListItemDto> response = _mapper.Map<GetListResponse<GetListVoyageListItemDto>>(voyages);
            return response;
        }
    }
}