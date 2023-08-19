using Application.Features.Pods.Constants;
using Application.Features.Pods.Constants;
using Application.Features.Pods.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Pods.Constants.PodsOperationClaims;

namespace Application.Features.Pods.Commands.Delete;

public class DeletePodCommand : IRequest<DeletedPodResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, PodsOperationClaims.Delete };

    public class DeletePodCommandHandler : IRequestHandler<DeletePodCommand, DeletedPodResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPodRepository _podRepository;
        private readonly PodBusinessRules _podBusinessRules;

        public DeletePodCommandHandler(IMapper mapper, IPodRepository podRepository,
                                         PodBusinessRules podBusinessRules)
        {
            _mapper = mapper;
            _podRepository = podRepository;
            _podBusinessRules = podBusinessRules;
        }

        public async Task<DeletedPodResponse> Handle(DeletePodCommand request, CancellationToken cancellationToken)
        {
            Pod? pod = await _podRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _podBusinessRules.PodShouldExistWhenSelected(pod);

            await _podRepository.DeleteAsync(pod!);

            DeletedPodResponse response = _mapper.Map<DeletedPodResponse>(pod);
            return response;
        }
    }
}