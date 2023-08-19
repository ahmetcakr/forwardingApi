using Application.Features.Demurrages.Constants;
using Application.Features.Demurrages.Constants;
using Application.Features.Demurrages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Demurrages.Constants.DemurragesOperationClaims;

namespace Application.Features.Demurrages.Commands.Delete;

public class DeleteDemurrageCommand : IRequest<DeletedDemurrageResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, DemurragesOperationClaims.Delete };

    public class DeleteDemurrageCommandHandler : IRequestHandler<DeleteDemurrageCommand, DeletedDemurrageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDemurrageRepository _demurrageRepository;
        private readonly DemurrageBusinessRules _demurrageBusinessRules;

        public DeleteDemurrageCommandHandler(IMapper mapper, IDemurrageRepository demurrageRepository,
                                         DemurrageBusinessRules demurrageBusinessRules)
        {
            _mapper = mapper;
            _demurrageRepository = demurrageRepository;
            _demurrageBusinessRules = demurrageBusinessRules;
        }

        public async Task<DeletedDemurrageResponse> Handle(DeleteDemurrageCommand request, CancellationToken cancellationToken)
        {
            Demurrage? demurrage = await _demurrageRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _demurrageBusinessRules.DemurrageShouldExistWhenSelected(demurrage);

            await _demurrageRepository.DeleteAsync(demurrage!);

            DeletedDemurrageResponse response = _mapper.Map<DeletedDemurrageResponse>(demurrage);
            return response;
        }
    }
}