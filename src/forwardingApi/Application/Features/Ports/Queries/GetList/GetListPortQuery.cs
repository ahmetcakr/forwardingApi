using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Ports.Queries.GetList;

public class GetListPortQuery : IRequest<GetListResponse<GetListPortListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => $"GetListPorts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetPorts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListPortQueryHandler : IRequestHandler<GetListPortQuery, GetListResponse<GetListPortListItemDto>>
    {
        private readonly IPortRepository _portRepository;
        private readonly IMapper _mapper;

        public GetListPortQueryHandler(IPortRepository portRepository, IMapper mapper)
        {
            _portRepository = portRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPortListItemDto>> Handle(GetListPortQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Port> ports = await _portRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPortListItemDto> response = _mapper.Map<GetListResponse<GetListPortListItemDto>>(ports);
            return response;
        }
    }
}