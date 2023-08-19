using Application.Features.Ships.Constants;
using Application.Features.Ships.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Ships.Constants.ShipsOperationClaims;

namespace Application.Features.Ships.Commands.Update;

public class UpdateShipCommand : IRequest<UpdatedShipResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string ShipName { get; set; }

    public string[] Roles => new[] { Admin, Write, ShipsOperationClaims.Update };

    public class UpdateShipCommandHandler : IRequestHandler<UpdateShipCommand, UpdatedShipResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShipRepository _shipRepository;
        private readonly ShipBusinessRules _shipBusinessRules;

        public UpdateShipCommandHandler(IMapper mapper, IShipRepository shipRepository,
                                         ShipBusinessRules shipBusinessRules)
        {
            _mapper = mapper;
            _shipRepository = shipRepository;
            _shipBusinessRules = shipBusinessRules;
        }

        public async Task<UpdatedShipResponse> Handle(UpdateShipCommand request, CancellationToken cancellationToken)
        {
            Ship? ship = await _shipRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _shipBusinessRules.ShipShouldExistWhenSelected(ship);
            ship = _mapper.Map(request, ship);

            await _shipRepository.UpdateAsync(ship!);

            UpdatedShipResponse response = _mapper.Map<UpdatedShipResponse>(ship);
            return response;
        }
    }
}