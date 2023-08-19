using Application.Features.Routes.Constants;
using Application.Features.Routes.Constants;
using Application.Features.Routes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Routes.Constants.RoutesOperationClaims;

namespace Application.Features.Routes.Commands.Delete;

public class DeleteRouteCommand : IRequest<DeletedRouteResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, RoutesOperationClaims.Delete };

    public class DeleteRouteCommandHandler : IRequestHandler<DeleteRouteCommand, DeletedRouteResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRouteRepository _routeRepository;
        private readonly RouteBusinessRules _routeBusinessRules;

        public DeleteRouteCommandHandler(IMapper mapper, IRouteRepository routeRepository,
                                         RouteBusinessRules routeBusinessRules)
        {
            _mapper = mapper;
            _routeRepository = routeRepository;
            _routeBusinessRules = routeBusinessRules;
        }

        public async Task<DeletedRouteResponse> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
        {
            Route? route = await _routeRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _routeBusinessRules.RouteShouldExistWhenSelected(route);

            await _routeRepository.DeleteAsync(route!);

            DeletedRouteResponse response = _mapper.Map<DeletedRouteResponse>(route);
            return response;
        }
    }
}