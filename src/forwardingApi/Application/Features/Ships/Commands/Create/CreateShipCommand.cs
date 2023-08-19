using Application.Features.Ships.Constants;
using Application.Features.Ships.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Ships.Constants.ShipsOperationClaims;

namespace Application.Features.Ships.Commands.Create;

public class CreateShipCommand : IRequest<CreatedShipResponse>, ISecuredRequest, ITransactionalRequest
{
    public string ShipName { get; set; }

    public string[] Roles => new[] { Admin, Write, ShipsOperationClaims.Create };

    public class CreateShipCommandHandler : IRequestHandler<CreateShipCommand, CreatedShipResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShipRepository _shipRepository;
        private readonly ShipBusinessRules _shipBusinessRules;

        public CreateShipCommandHandler(IMapper mapper, IShipRepository shipRepository,
                                         ShipBusinessRules shipBusinessRules)
        {
            _mapper = mapper;
            _shipRepository = shipRepository;
            _shipBusinessRules = shipBusinessRules;
        }

        public async Task<CreatedShipResponse> Handle(CreateShipCommand request, CancellationToken cancellationToken)
        {
            Ship ship = _mapper.Map<Ship>(request);

            await _shipRepository.AddAsync(ship);

            CreatedShipResponse response = _mapper.Map<CreatedShipResponse>(ship);
            return response;
        }
    }
}