using Application.Features.Pods.Constants;
using Application.Features.Pods.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Pods.Constants.PodsOperationClaims;

namespace Application.Features.Pods.Queries.GetById;

public class GetByIdPodQuery : IRequest<GetByIdPodResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdPodQueryHandler : IRequestHandler<GetByIdPodQuery, GetByIdPodResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPodRepository _podRepository;
        private readonly PodBusinessRules _podBusinessRules;

        public GetByIdPodQueryHandler(IMapper mapper, IPodRepository podRepository, PodBusinessRules podBusinessRules)
        {
            _mapper = mapper;
            _podRepository = podRepository;
            _podBusinessRules = podBusinessRules;
        }

        public async Task<GetByIdPodResponse> Handle(GetByIdPodQuery request, CancellationToken cancellationToken)
        {
            Pod? pod = await _podRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _podBusinessRules.PodShouldExistWhenSelected(pod);

            GetByIdPodResponse response = _mapper.Map<GetByIdPodResponse>(pod);
            return response;
        }
    }
}