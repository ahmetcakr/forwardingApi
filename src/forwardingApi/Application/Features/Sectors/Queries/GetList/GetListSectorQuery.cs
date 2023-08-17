using Application.Features.Sectors.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Sectors.Constants.SectorsOperationClaims;

namespace Application.Features.Sectors.Queries.GetList;

public class GetListSectorQuery : IRequest<GetListResponse<GetListSectorListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListSectorQueryHandler : IRequestHandler<GetListSectorQuery, GetListResponse<GetListSectorListItemDto>>
    {
        private readonly ISectorRepository _sectorRepository;
        private readonly IMapper _mapper;

        public GetListSectorQueryHandler(ISectorRepository sectorRepository, IMapper mapper)
        {
            _sectorRepository = sectorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSectorListItemDto>> Handle(GetListSectorQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Sector> sectors = await _sectorRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSectorListItemDto> response = _mapper.Map<GetListResponse<GetListSectorListItemDto>>(sectors);
            return response;
        }
    }
}