using Application.Features.CustomerGroups.Constants;
using Application.Features.CustomerGroups.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerGroups.Constants.CustomerGroupsOperationClaims;

namespace Application.Features.CustomerGroups.Commands.Update;

public class UpdateCustomerGroupCommand : IRequest<UpdatedCustomerGroupResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int GroupId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerGroupsOperationClaims.Update };

    public class UpdateCustomerGroupCommandHandler : IRequestHandler<UpdateCustomerGroupCommand, UpdatedCustomerGroupResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerGroupRepository _customerGroupRepository;
        private readonly CustomerGroupBusinessRules _customerGroupBusinessRules;

        public UpdateCustomerGroupCommandHandler(IMapper mapper, ICustomerGroupRepository customerGroupRepository,
                                         CustomerGroupBusinessRules customerGroupBusinessRules)
        {
            _mapper = mapper;
            _customerGroupRepository = customerGroupRepository;
            _customerGroupBusinessRules = customerGroupBusinessRules;
        }

        public async Task<UpdatedCustomerGroupResponse> Handle(UpdateCustomerGroupCommand request, CancellationToken cancellationToken)
        {
            CustomerGroup? customerGroup = await _customerGroupRepository.GetAsync(predicate: cg => cg.Id == request.Id, cancellationToken: cancellationToken);
            await _customerGroupBusinessRules.CustomerGroupShouldExistWhenSelected(customerGroup);
            customerGroup = _mapper.Map(request, customerGroup);

            await _customerGroupRepository.UpdateAsync(customerGroup!);

            UpdatedCustomerGroupResponse response = _mapper.Map<UpdatedCustomerGroupResponse>(customerGroup);
            return response;
        }
    }
}