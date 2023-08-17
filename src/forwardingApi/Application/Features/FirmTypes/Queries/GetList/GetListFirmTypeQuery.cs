using Application.Features.FirmTypes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.FirmTypes.Constants.FirmTypesOperationClaims;

namespace Application.Features.FirmTypes.Queries.GetList;

public class GetListFirmTypeQuery : IRequest<GetListResponse<GetListFirmTypeListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListFirmTypeQueryHandler : IRequestHandler<GetListFirmTypeQuery, GetListResponse<GetListFirmTypeListItemDto>>
    {
        private readonly IFirmTypeRepository _firmTypeRepository;
        private readonly IMapper _mapper;

        public GetListFirmTypeQueryHandler(IFirmTypeRepository firmTypeRepository, IMapper mapper)
        {
            _firmTypeRepository = firmTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListFirmTypeListItemDto>> Handle(GetListFirmTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<FirmType> firmTypes = await _firmTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListFirmTypeListItemDto> response = _mapper.Map<GetListResponse<GetListFirmTypeListItemDto>>(firmTypes);
            return response;
        }
    }
}