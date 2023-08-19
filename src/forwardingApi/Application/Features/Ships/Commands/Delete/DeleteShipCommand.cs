using Application.Features.Ships.Constants;
using Application.Features.Ships.Constants;
using Application.Features.Ships.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Ships.Constants.ShipsOperationClaims;

namespace Application.Features.Ships.Commands.Delete;

public class DeleteShipCommand : IRequest<DeletedShipResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ShipsOperationClaims.Delete };

    public class DeleteShipCommandHandler : IRequestHandler<DeleteShipCommand, DeletedShipResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShipRepository _shipRepository;
        private readonly ShipBusinessRules _shipBusinessRules;

        public DeleteShipCommandHandler(IMapper mapper, IShipRepository shipRepository,
                                         ShipBusinessRules shipBusinessRules)
        {
            _mapper = mapper;
            _shipRepository = shipRepository;
            _shipBusinessRules = shipBusinessRules;
        }

        public async Task<DeletedShipResponse> Handle(DeleteShipCommand request, CancellationToken cancellationToken)
        {
            Ship? ship = await _shipRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _shipBusinessRules.ShipShouldExistWhenSelected(ship);

            await _shipRepository.DeleteAsync(ship!);

            DeletedShipResponse response = _mapper.Map<DeletedShipResponse>(ship);
            return response;
        }
    }
}