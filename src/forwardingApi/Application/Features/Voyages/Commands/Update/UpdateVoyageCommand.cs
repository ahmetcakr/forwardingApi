using Application.Features.Voyages.Constants;
using Application.Features.Voyages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Voyages.Constants.VoyagesOperationClaims;

namespace Application.Features.Voyages.Commands.Update;

public class UpdateVoyageCommand : IRequest<UpdatedVoyageResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string VoyageName { get; set; }

    public string[] Roles => new[] { Admin, Write, VoyagesOperationClaims.Update };

    public class UpdateVoyageCommandHandler : IRequestHandler<UpdateVoyageCommand, UpdatedVoyageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVoyageRepository _voyageRepository;
        private readonly VoyageBusinessRules _voyageBusinessRules;

        public UpdateVoyageCommandHandler(IMapper mapper, IVoyageRepository voyageRepository,
                                         VoyageBusinessRules voyageBusinessRules)
        {
            _mapper = mapper;
            _voyageRepository = voyageRepository;
            _voyageBusinessRules = voyageBusinessRules;
        }

        public async Task<UpdatedVoyageResponse> Handle(UpdateVoyageCommand request, CancellationToken cancellationToken)
        {
            Voyage? voyage = await _voyageRepository.GetAsync(predicate: v => v.Id == request.Id, cancellationToken: cancellationToken);
            await _voyageBusinessRules.VoyageShouldExistWhenSelected(voyage);
            voyage = _mapper.Map(request, voyage);

            await _voyageRepository.UpdateAsync(voyage!);

            UpdatedVoyageResponse response = _mapper.Map<UpdatedVoyageResponse>(voyage);
            return response;
        }
    }
}