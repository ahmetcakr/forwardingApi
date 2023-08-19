using Application.Features.Demurrages.Constants;
using Application.Features.Demurrages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Demurrages.Constants.DemurragesOperationClaims;

namespace Application.Features.Demurrages.Commands.Update;

public class UpdateDemurrageCommand : IRequest<UpdatedDemurrageResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public DateTime? StartDate { get; set; }
    public int? Day { get; set; }
    public int? Fee { get; set; }

    public string[] Roles => new[] { Admin, Write, DemurragesOperationClaims.Update };

    public class UpdateDemurrageCommandHandler : IRequestHandler<UpdateDemurrageCommand, UpdatedDemurrageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDemurrageRepository _demurrageRepository;
        private readonly DemurrageBusinessRules _demurrageBusinessRules;

        public UpdateDemurrageCommandHandler(IMapper mapper, IDemurrageRepository demurrageRepository,
                                         DemurrageBusinessRules demurrageBusinessRules)
        {
            _mapper = mapper;
            _demurrageRepository = demurrageRepository;
            _demurrageBusinessRules = demurrageBusinessRules;
        }

        public async Task<UpdatedDemurrageResponse> Handle(UpdateDemurrageCommand request, CancellationToken cancellationToken)
        {
            Demurrage? demurrage = await _demurrageRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _demurrageBusinessRules.DemurrageShouldExistWhenSelected(demurrage);
            demurrage = _mapper.Map(request, demurrage);

            await _demurrageRepository.UpdateAsync(demurrage!);

            UpdatedDemurrageResponse response = _mapper.Map<UpdatedDemurrageResponse>(demurrage);
            return response;
        }
    }
}