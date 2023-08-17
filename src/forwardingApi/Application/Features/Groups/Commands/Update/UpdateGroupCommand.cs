using Application.Features.Groups.Constants;
using Application.Features.Groups.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Groups.Constants.GroupsOperationClaims;

namespace Application.Features.Groups.Commands.Update;

public class UpdateGroupCommand : IRequest<UpdatedGroupResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, GroupsOperationClaims.Update };

    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, UpdatedGroupResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;
        private readonly GroupBusinessRules _groupBusinessRules;

        public UpdateGroupCommandHandler(IMapper mapper, IGroupRepository groupRepository,
                                         GroupBusinessRules groupBusinessRules)
        {
            _mapper = mapper;
            _groupRepository = groupRepository;
            _groupBusinessRules = groupBusinessRules;
        }

        public async Task<UpdatedGroupResponse> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            Group? group = await _groupRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _groupBusinessRules.GroupShouldExistWhenSelected(group);
            group = _mapper.Map(request, group);

            await _groupRepository.UpdateAsync(group!);

            UpdatedGroupResponse response = _mapper.Map<UpdatedGroupResponse>(group);
            return response;
        }
    }
}