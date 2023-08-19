using Application.Features.Pods.Constants;
using Application.Features.Pods.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Pods.Constants.PodsOperationClaims;

namespace Application.Features.Pods.Commands.Create;

public class CreatePodCommand : IRequest<CreatedPodResponse>, ISecuredRequest, ITransactionalRequest
{
    public string PodName { get; set; }

    public string[] Roles => new[] { Admin, Write, PodsOperationClaims.Create };

    public class CreatePodCommandHandler : IRequestHandler<CreatePodCommand, CreatedPodResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPodRepository _podRepository;
        private readonly PodBusinessRules _podBusinessRules;

        public CreatePodCommandHandler(IMapper mapper, IPodRepository podRepository,
                                         PodBusinessRules podBusinessRules)
        {
            _mapper = mapper;
            _podRepository = podRepository;
            _podBusinessRules = podBusinessRules;
        }

        public async Task<CreatedPodResponse> Handle(CreatePodCommand request, CancellationToken cancellationToken)
        {
            Pod pod = _mapper.Map<Pod>(request);

            await _podRepository.AddAsync(pod);

            CreatedPodResponse response = _mapper.Map<CreatedPodResponse>(pod);
            return response;
        }
    }
}