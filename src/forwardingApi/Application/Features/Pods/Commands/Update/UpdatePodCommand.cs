using Application.Features.Pods.Constants;
using Application.Features.Pods.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Pods.Constants.PodsOperationClaims;

namespace Application.Features.Pods.Commands.Update;

public class UpdatePodCommand : IRequest<UpdatedPodResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string PodName { get; set; }

    public string[] Roles => new[] { Admin, Write, PodsOperationClaims.Update };

    public class UpdatePodCommandHandler : IRequestHandler<UpdatePodCommand, UpdatedPodResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPodRepository _podRepository;
        private readonly PodBusinessRules _podBusinessRules;

        public UpdatePodCommandHandler(IMapper mapper, IPodRepository podRepository,
                                         PodBusinessRules podBusinessRules)
        {
            _mapper = mapper;
            _podRepository = podRepository;
            _podBusinessRules = podBusinessRules;
        }

        public async Task<UpdatedPodResponse> Handle(UpdatePodCommand request, CancellationToken cancellationToken)
        {
            Pod? pod = await _podRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _podBusinessRules.PodShouldExistWhenSelected(pod);
            pod = _mapper.Map(request, pod);

            await _podRepository.UpdateAsync(pod!);

            UpdatedPodResponse response = _mapper.Map<UpdatedPodResponse>(pod);
            return response;
        }
    }
}