using Application.Features.CustomerEBills.Constants;
using Application.Features.CustomerEBills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerEBills.Constants.CustomerEBillsOperationClaims;

namespace Application.Features.CustomerEBills.Commands.Create;

public class CreateCustomerEBillCommand : IRequest<CreatedCustomerEBillResponse>, ISecuredRequest, ITransactionalRequest
{
    public int CustomerId { get; set; }
    public int EBillId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerEBillsOperationClaims.Create };

    public class CreateCustomerEBillCommandHandler : IRequestHandler<CreateCustomerEBillCommand, CreatedCustomerEBillResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerEBillRepository _customerEBillRepository;
        private readonly CustomerEBillBusinessRules _customerEBillBusinessRules;

        public CreateCustomerEBillCommandHandler(IMapper mapper, ICustomerEBillRepository customerEBillRepository,
                                         CustomerEBillBusinessRules customerEBillBusinessRules)
        {
            _mapper = mapper;
            _customerEBillRepository = customerEBillRepository;
            _customerEBillBusinessRules = customerEBillBusinessRules;
        }

        public async Task<CreatedCustomerEBillResponse> Handle(CreateCustomerEBillCommand request, CancellationToken cancellationToken)
        {
            CustomerEBill customerEBill = _mapper.Map<CustomerEBill>(request);

            await _customerEBillRepository.AddAsync(customerEBill);

            CreatedCustomerEBillResponse response = _mapper.Map<CreatedCustomerEBillResponse>(customerEBill);
            return response;
        }
    }
}