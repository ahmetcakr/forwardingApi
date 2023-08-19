using Application.Features.Routes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Routes.Constants.RoutesOperationClaims;

namespace Application.Features.Routes.Queries.GetList;

public class GetListRouteQuery : IRequest<GetListResponse<GetListRouteListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListRouteQueryHandler : IRequestHandler<GetListRouteQuery, GetListResponse<GetListRouteListItemDto>>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;

        public GetListRouteQueryHandler(IRouteRepository routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRouteListItemDto>> Handle(GetListRouteQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Route> routes = await _routeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRouteListItemDto> response = _mapper.Map<GetListResponse<GetListRouteListItemDto>>(routes);
            return response;
        }
    }
}