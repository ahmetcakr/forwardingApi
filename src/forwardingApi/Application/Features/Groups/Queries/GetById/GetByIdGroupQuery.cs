using Application.Features.Groups.Constants;
using Application.Features.Groups.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Groups.Constants.GroupsOperationClaims;

namespace Application.Features.Groups.Queries.GetById;

public class GetByIdGroupQuery : IRequest<GetByIdGroupResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdGroupQueryHandler : IRequestHandler<GetByIdGroupQuery, GetByIdGroupResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;
        private readonly GroupBusinessRules _groupBusinessRules;

        public GetByIdGroupQueryHandler(IMapper mapper, IGroupRepository groupRepository, GroupBusinessRules groupBusinessRules)
        {
            _mapper = mapper;
            _groupRepository = groupRepository;
            _groupBusinessRules = groupBusinessRules;
        }

        public async Task<GetByIdGroupResponse> Handle(GetByIdGroupQuery request, CancellationToken cancellationToken)
        {
            Group? group = await _groupRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _groupBusinessRules.GroupShouldExistWhenSelected(group);

            GetByIdGroupResponse response = _mapper.Map<GetByIdGroupResponse>(group);
            return response;
        }
    }
}