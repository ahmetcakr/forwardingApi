using Application.Features.CustomerGroups.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CustomerGroups.Constants.CustomerGroupsOperationClaims;

namespace Application.Features.CustomerGroups.Queries.GetList;

public class GetListCustomerGroupQuery : IRequest<GetListResponse<GetListCustomerGroupListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCustomerGroupQueryHandler : IRequestHandler<GetListCustomerGroupQuery, GetListResponse<GetListCustomerGroupListItemDto>>
    {
        private readonly ICustomerGroupRepository _customerGroupRepository;
        private readonly IMapper _mapper;

        public GetListCustomerGroupQueryHandler(ICustomerGroupRepository customerGroupRepository, IMapper mapper)
        {
            _customerGroupRepository = customerGroupRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCustomerGroupListItemDto>> Handle(GetListCustomerGroupQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CustomerGroup> customerGroups = await _customerGroupRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCustomerGroupListItemDto> response = _mapper.Map<GetListResponse<GetListCustomerGroupListItemDto>>(customerGroups);
            return response;
        }
    }
}