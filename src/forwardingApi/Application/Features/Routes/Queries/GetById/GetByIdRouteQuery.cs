using Application.Features.Routes.Constants;
using Application.Features.Routes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Routes.Constants.RoutesOperationClaims;

namespace Application.Features.Routes.Queries.GetById;

public class GetByIdRouteQuery : IRequest<GetByIdRouteResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdRouteQueryHandler : IRequestHandler<GetByIdRouteQuery, GetByIdRouteResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRouteRepository _routeRepository;
        private readonly RouteBusinessRules _routeBusinessRules;

        public GetByIdRouteQueryHandler(IMapper mapper, IRouteRepository routeRepository, RouteBusinessRules routeBusinessRules)
        {
            _mapper = mapper;
            _routeRepository = routeRepository;
            _routeBusinessRules = routeBusinessRules;
        }

        public async Task<GetByIdRouteResponse> Handle(GetByIdRouteQuery request, CancellationToken cancellationToken)
        {
            Route? route = await _routeRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _routeBusinessRules.RouteShouldExistWhenSelected(route);

            GetByIdRouteResponse response = _mapper.Map<GetByIdRouteResponse>(route);
            return response;
        }
    }
}