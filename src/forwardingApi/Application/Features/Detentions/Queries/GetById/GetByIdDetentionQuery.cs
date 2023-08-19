using Application.Features.Detentions.Constants;
using Application.Features.Detentions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Detentions.Constants.DetentionsOperationClaims;

namespace Application.Features.Detentions.Queries.GetById;

public class GetByIdDetentionQuery : IRequest<GetByIdDetentionResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdDetentionQueryHandler : IRequestHandler<GetByIdDetentionQuery, GetByIdDetentionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDetentionRepository _detentionRepository;
        private readonly DetentionBusinessRules _detentionBusinessRules;

        public GetByIdDetentionQueryHandler(IMapper mapper, IDetentionRepository detentionRepository, DetentionBusinessRules detentionBusinessRules)
        {
            _mapper = mapper;
            _detentionRepository = detentionRepository;
            _detentionBusinessRules = detentionBusinessRules;
        }

        public async Task<GetByIdDetentionResponse> Handle(GetByIdDetentionQuery request, CancellationToken cancellationToken)
        {
            Detention? detention = await _detentionRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _detentionBusinessRules.DetentionShouldExistWhenSelected(detention);

            GetByIdDetentionResponse response = _mapper.Map<GetByIdDetentionResponse>(detention);
            return response;
        }
    }
}