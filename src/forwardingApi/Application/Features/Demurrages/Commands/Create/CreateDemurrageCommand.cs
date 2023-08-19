using Application.Features.Demurrages.Constants;
using Application.Features.Demurrages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Demurrages.Constants.DemurragesOperationClaims;

namespace Application.Features.Demurrages.Commands.Create;

public class CreateDemurrageCommand : IRequest<CreatedDemurrageResponse>, ISecuredRequest, ITransactionalRequest
{
    public DateTime? StartDate { get; set; }
    public int? Day { get; set; }
    public int? Fee { get; set; }

    public string[] Roles => new[] { Admin, Write, DemurragesOperationClaims.Create };

    public class CreateDemurrageCommandHandler : IRequestHandler<CreateDemurrageCommand, CreatedDemurrageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDemurrageRepository _demurrageRepository;
        private readonly DemurrageBusinessRules _demurrageBusinessRules;

        public CreateDemurrageCommandHandler(IMapper mapper, IDemurrageRepository demurrageRepository,
                                         DemurrageBusinessRules demurrageBusinessRules)
        {
            _mapper = mapper;
            _demurrageRepository = demurrageRepository;
            _demurrageBusinessRules = demurrageBusinessRules;
        }

        public async Task<CreatedDemurrageResponse> Handle(CreateDemurrageCommand request, CancellationToken cancellationToken)
        {
            Demurrage demurrage = _mapper.Map<Demurrage>(request);

            await _demurrageRepository.AddAsync(demurrage);

            CreatedDemurrageResponse response = _mapper.Map<CreatedDemurrageResponse>(demurrage);
            return response;
        }
    }
}