using Application.Features.Voyages.Constants;
using Application.Features.Voyages.Constants;
using Application.Features.Voyages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Voyages.Constants.VoyagesOperationClaims;

namespace Application.Features.Voyages.Commands.Delete;

public class DeleteVoyageCommand : IRequest<DeletedVoyageResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, VoyagesOperationClaims.Delete };

    public class DeleteVoyageCommandHandler : IRequestHandler<DeleteVoyageCommand, DeletedVoyageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVoyageRepository _voyageRepository;
        private readonly VoyageBusinessRules _voyageBusinessRules;

        public DeleteVoyageCommandHandler(IMapper mapper, IVoyageRepository voyageRepository,
                                         VoyageBusinessRules voyageBusinessRules)
        {
            _mapper = mapper;
            _voyageRepository = voyageRepository;
            _voyageBusinessRules = voyageBusinessRules;
        }

        public async Task<DeletedVoyageResponse> Handle(DeleteVoyageCommand request, CancellationToken cancellationToken)
        {
            Voyage? voyage = await _voyageRepository.GetAsync(predicate: v => v.Id == request.Id, cancellationToken: cancellationToken);
            await _voyageBusinessRules.VoyageShouldExistWhenSelected(voyage);

            await _voyageRepository.DeleteAsync(voyage!);

            DeletedVoyageResponse response = _mapper.Map<DeletedVoyageResponse>(voyage);
            return response;
        }
    }
}