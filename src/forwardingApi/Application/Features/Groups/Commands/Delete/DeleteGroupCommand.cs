using Application.Features.Groups.Constants;
using Application.Features.Groups.Constants;
using Application.Features.Groups.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Groups.Constants.GroupsOperationClaims;

namespace Application.Features.Groups.Commands.Delete;

public class DeleteGroupCommand : IRequest<DeletedGroupResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, GroupsOperationClaims.Delete };

    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, DeletedGroupResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;
        private readonly GroupBusinessRules _groupBusinessRules;

        public DeleteGroupCommandHandler(IMapper mapper, IGroupRepository groupRepository,
                                         GroupBusinessRules groupBusinessRules)
        {
            _mapper = mapper;
            _groupRepository = groupRepository;
            _groupBusinessRules = groupBusinessRules;
        }

        public async Task<DeletedGroupResponse> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            Group? group = await _groupRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _groupBusinessRules.GroupShouldExistWhenSelected(group);

            await _groupRepository.DeleteAsync(group!);

            DeletedGroupResponse response = _mapper.Map<DeletedGroupResponse>(group);
            return response;
        }
    }
}