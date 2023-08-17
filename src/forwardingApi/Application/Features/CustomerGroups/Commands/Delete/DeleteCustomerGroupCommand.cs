using Application.Features.CustomerGroups.Constants;
using Application.Features.CustomerGroups.Constants;
using Application.Features.CustomerGroups.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerGroups.Constants.CustomerGroupsOperationClaims;

namespace Application.Features.CustomerGroups.Commands.Delete;

public class DeleteCustomerGroupCommand : IRequest<DeletedCustomerGroupResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerGroupsOperationClaims.Delete };

    public class DeleteCustomerGroupCommandHandler : IRequestHandler<DeleteCustomerGroupCommand, DeletedCustomerGroupResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerGroupRepository _customerGroupRepository;
        private readonly CustomerGroupBusinessRules _customerGroupBusinessRules;

        public DeleteCustomerGroupCommandHandler(IMapper mapper, ICustomerGroupRepository customerGroupRepository,
                                         CustomerGroupBusinessRules customerGroupBusinessRules)
        {
            _mapper = mapper;
            _customerGroupRepository = customerGroupRepository;
            _customerGroupBusinessRules = customerGroupBusinessRules;
        }

        public async Task<DeletedCustomerGroupResponse> Handle(DeleteCustomerGroupCommand request, CancellationToken cancellationToken)
        {
            CustomerGroup? customerGroup = await _customerGroupRepository.GetAsync(predicate: cg => cg.Id == request.Id, cancellationToken: cancellationToken);
            await _customerGroupBusinessRules.CustomerGroupShouldExistWhenSelected(customerGroup);

            await _customerGroupRepository.DeleteAsync(customerGroup!);

            DeletedCustomerGroupResponse response = _mapper.Map<DeletedCustomerGroupResponse>(customerGroup);
            return response;
        }
    }
}