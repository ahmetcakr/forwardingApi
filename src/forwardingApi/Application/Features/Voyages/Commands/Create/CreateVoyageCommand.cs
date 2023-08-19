using Application.Features.Voyages.Constants;
using Application.Features.Voyages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Voyages.Constants.VoyagesOperationClaims;

namespace Application.Features.Voyages.Commands.Create;

public class CreateVoyageCommand : IRequest<CreatedVoyageResponse>, ISecuredRequest, ITransactionalRequest
{
    public string VoyageName { get; set; }

    public string[] Roles => new[] { Admin, Write, VoyagesOperationClaims.Create };

    public class CreateVoyageCommandHandler : IRequestHandler<CreateVoyageCommand, CreatedVoyageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVoyageRepository _voyageRepository;
        private readonly VoyageBusinessRules _voyageBusinessRules;

        public CreateVoyageCommandHandler(IMapper mapper, IVoyageRepository voyageRepository,
                                         VoyageBusinessRules voyageBusinessRules)
        {
            _mapper = mapper;
            _voyageRepository = voyageRepository;
            _voyageBusinessRules = voyageBusinessRules;
        }

        public async Task<CreatedVoyageResponse> Handle(CreateVoyageCommand request, CancellationToken cancellationToken)
        {
            Voyage voyage = _mapper.Map<Voyage>(request);

            await _voyageRepository.AddAsync(voyage);

            CreatedVoyageResponse response = _mapper.Map<CreatedVoyageResponse>(voyage);
            return response;
        }
    }
}