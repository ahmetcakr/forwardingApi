using Application.Features.CustomerEBills.Constants;
using Application.Features.CustomerEBills.Constants;
using Application.Features.CustomerEBills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerEBills.Constants.CustomerEBillsOperationClaims;

namespace Application.Features.CustomerEBills.Commands.Delete;

public class DeleteCustomerEBillCommand : IRequest<DeletedCustomerEBillResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerEBillsOperationClaims.Delete };

    public class DeleteCustomerEBillCommandHandler : IRequestHandler<DeleteCustomerEBillCommand, DeletedCustomerEBillResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerEBillRepository _customerEBillRepository;
        private readonly CustomerEBillBusinessRules _customerEBillBusinessRules;

        public DeleteCustomerEBillCommandHandler(IMapper mapper, ICustomerEBillRepository customerEBillRepository,
                                         CustomerEBillBusinessRules customerEBillBusinessRules)
        {
            _mapper = mapper;
            _customerEBillRepository = customerEBillRepository;
            _customerEBillBusinessRules = customerEBillBusinessRules;
        }

        public async Task<DeletedCustomerEBillResponse> Handle(DeleteCustomerEBillCommand request, CancellationToken cancellationToken)
        {
            CustomerEBill? customerEBill = await _customerEBillRepository.GetAsync(predicate: ceb => ceb.Id == request.Id, cancellationToken: cancellationToken);
            await _customerEBillBusinessRules.CustomerEBillShouldExistWhenSelected(customerEBill);

            await _customerEBillRepository.DeleteAsync(customerEBill!);

            DeletedCustomerEBillResponse response = _mapper.Map<DeletedCustomerEBillResponse>(customerEBill);
            return response;
        }
    }
}