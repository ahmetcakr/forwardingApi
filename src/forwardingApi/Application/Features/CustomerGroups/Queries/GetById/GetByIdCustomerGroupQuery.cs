using Application.Features.CustomerGroups.Constants;
using Application.Features.CustomerGroups.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomerGroups.Constants.CustomerGroupsOperationClaims;

namespace Application.Features.CustomerGroups.Queries.GetById;

public class GetByIdCustomerGroupQuery : IRequest<GetByIdCustomerGroupResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCustomerGroupQueryHandler : IRequestHandler<GetByIdCustomerGroupQuery, GetByIdCustomerGroupResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerGroupRepository _customerGroupRepository;
        private readonly CustomerGroupBusinessRules _customerGroupBusinessRules;

        public GetByIdCustomerGroupQueryHandler(IMapper mapper, ICustomerGroupRepository customerGroupRepository, CustomerGroupBusinessRules customerGroupBusinessRules)
        {
            _mapper = mapper;
            _customerGroupRepository = customerGroupRepository;
            _customerGroupBusinessRules = customerGroupBusinessRules;
        }

        public async Task<GetByIdCustomerGroupResponse> Handle(GetByIdCustomerGroupQuery request, CancellationToken cancellationToken)
        {
            CustomerGroup? customerGroup = await _customerGroupRepository.GetAsync(predicate: cg => cg.Id == request.Id, cancellationToken: cancellationToken);
            await _customerGroupBusinessRules.CustomerGroupShouldExistWhenSelected(customerGroup);

            GetByIdCustomerGroupResponse response = _mapper.Map<GetByIdCustomerGroupResponse>(customerGroup);
            return response;
        }
    }
}