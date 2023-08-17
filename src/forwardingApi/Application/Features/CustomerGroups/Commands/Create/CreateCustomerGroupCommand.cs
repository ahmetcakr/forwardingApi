using Application.Features.CustomerGroups.Constants;
using Application.Features.CustomerGroups.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerGroups.Constants.CustomerGroupsOperationClaims;

namespace Application.Features.CustomerGroups.Commands.Create;

public class CreateCustomerGroupCommand : IRequest<CreatedCustomerGroupResponse>, ISecuredRequest, ITransactionalRequest
{
    public int CustomerId { get; set; }
    public int GroupId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerGroupsOperationClaims.Create };

    public class CreateCustomerGroupCommandHandler : IRequestHandler<CreateCustomerGroupCommand, CreatedCustomerGroupResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerGroupRepository _customerGroupRepository;
        private readonly CustomerGroupBusinessRules _customerGroupBusinessRules;

        public CreateCustomerGroupCommandHandler(IMapper mapper, ICustomerGroupRepository customerGroupRepository,
                                         CustomerGroupBusinessRules customerGroupBusinessRules)
        {
            _mapper = mapper;
            _customerGroupRepository = customerGroupRepository;
            _customerGroupBusinessRules = customerGroupBusinessRules;
        }

        public async Task<CreatedCustomerGroupResponse> Handle(CreateCustomerGroupCommand request, CancellationToken cancellationToken)
        {
            CustomerGroup customerGroup = _mapper.Map<CustomerGroup>(request);

            await _customerGroupRepository.AddAsync(customerGroup);

            CreatedCustomerGroupResponse response = _mapper.Map<CreatedCustomerGroupResponse>(customerGroup);
            return response;
        }
    }
}