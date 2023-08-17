using Application.Features.Groups.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Groups.Constants.GroupsOperationClaims;

namespace Application.Features.Groups.Queries.GetList;

public class GetListGroupQuery : IRequest<GetListResponse<GetListGroupListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListGroupQueryHandler : IRequestHandler<GetListGroupQuery, GetListResponse<GetListGroupListItemDto>>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GetListGroupQueryHandler(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListGroupListItemDto>> Handle(GetListGroupQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Group> groups = await _groupRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListGroupListItemDto> response = _mapper.Map<GetListResponse<GetListGroupListItemDto>>(groups);
            return response;
        }
    }
}