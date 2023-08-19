using Application.Features.Routes.Constants;
using Application.Features.Routes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Routes.Constants.RoutesOperationClaims;

namespace Application.Features.Routes.Commands.Update;

public class UpdateRouteCommand : IRequest<UpdatedRouteResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string? RouteName { get; set; }
    public string? RouteCode { get; set; }
    public string? RouteDescription { get; set; }
    public string? RouteType { get; set; }
    public string? RouteStatus { get; set; }
    public string? RouteNote { get; set; }

    public string[] Roles => new[] { Admin, Write, RoutesOperationClaims.Update };

    public class UpdateRouteCommandHandler : IRequestHandler<UpdateRouteCommand, UpdatedRouteResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRouteRepository _routeRepository;
        private readonly RouteBusinessRules _routeBusinessRules;

        public UpdateRouteCommandHandler(IMapper mapper, IRouteRepository routeRepository,
                                         RouteBusinessRules routeBusinessRules)
        {
            _mapper = mapper;
            _routeRepository = routeRepository;
            _routeBusinessRules = routeBusinessRules;
        }

        public async Task<UpdatedRouteResponse> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
        {
            Route? route = await _routeRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _routeBusinessRules.RouteShouldExistWhenSelected(route);
            route = _mapper.Map(request, route);

            await _routeRepository.UpdateAsync(route!);

            UpdatedRouteResponse response = _mapper.Map<UpdatedRouteResponse>(route);
            return response;
        }
    }
}