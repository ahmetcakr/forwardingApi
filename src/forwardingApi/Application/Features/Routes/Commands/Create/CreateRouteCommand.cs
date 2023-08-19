using Application.Features.Routes.Constants;
using Application.Features.Routes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Routes.Constants.RoutesOperationClaims;

namespace Application.Features.Routes.Commands.Create;

public class CreateRouteCommand : IRequest<CreatedRouteResponse>, ISecuredRequest, ITransactionalRequest
{
    public string? RouteName { get; set; }
    public string? RouteCode { get; set; }
    public string? RouteDescription { get; set; }
    public string? RouteType { get; set; }
    public string? RouteStatus { get; set; }
    public string? RouteNote { get; set; }

    public string[] Roles => new[] { Admin, Write, RoutesOperationClaims.Create };

    public class CreateRouteCommandHandler : IRequestHandler<CreateRouteCommand, CreatedRouteResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRouteRepository _routeRepository;
        private readonly RouteBusinessRules _routeBusinessRules;

        public CreateRouteCommandHandler(IMapper mapper, IRouteRepository routeRepository,
                                         RouteBusinessRules routeBusinessRules)
        {
            _mapper = mapper;
            _routeRepository = routeRepository;
            _routeBusinessRules = routeBusinessRules;
        }

        public async Task<CreatedRouteResponse> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
        {
            Route route = _mapper.Map<Route>(request);

            await _routeRepository.AddAsync(route);

            CreatedRouteResponse response = _mapper.Map<CreatedRouteResponse>(route);
            return response;
        }
    }
}