using Application.Features.Ships.Constants;
using Application.Features.Ships.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Ships.Constants.ShipsOperationClaims;

namespace Application.Features.Ships.Queries.GetById;

public class GetByIdShipQuery : IRequest<GetByIdShipResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdShipQueryHandler : IRequestHandler<GetByIdShipQuery, GetByIdShipResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShipRepository _shipRepository;
        private readonly ShipBusinessRules _shipBusinessRules;

        public GetByIdShipQueryHandler(IMapper mapper, IShipRepository shipRepository, ShipBusinessRules shipBusinessRules)
        {
            _mapper = mapper;
            _shipRepository = shipRepository;
            _shipBusinessRules = shipBusinessRules;
        }

        public async Task<GetByIdShipResponse> Handle(GetByIdShipQuery request, CancellationToken cancellationToken)
        {
            Ship? ship = await _shipRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _shipBusinessRules.ShipShouldExistWhenSelected(ship);

            GetByIdShipResponse response = _mapper.Map<GetByIdShipResponse>(ship);
            return response;
        }
    }
}