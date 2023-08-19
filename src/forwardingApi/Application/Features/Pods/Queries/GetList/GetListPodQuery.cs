using Application.Features.Pods.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Pods.Constants.PodsOperationClaims;

namespace Application.Features.Pods.Queries.GetList;

public class GetListPodQuery : IRequest<GetListResponse<GetListPodListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListPodQueryHandler : IRequestHandler<GetListPodQuery, GetListResponse<GetListPodListItemDto>>
    {
        private readonly IPodRepository _podRepository;
        private readonly IMapper _mapper;

        public GetListPodQueryHandler(IPodRepository podRepository, IMapper mapper)
        {
            _podRepository = podRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPodListItemDto>> Handle(GetListPodQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Pod> pods = await _podRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPodListItemDto> response = _mapper.Map<GetListResponse<GetListPodListItemDto>>(pods);
            return response;
        }
    }
}