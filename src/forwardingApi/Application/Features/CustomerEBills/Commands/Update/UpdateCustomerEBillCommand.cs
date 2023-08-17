using Application.Features.CustomerEBills.Constants;
using Application.Features.CustomerEBills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerEBills.Constants.CustomerEBillsOperationClaims;

namespace Application.Features.CustomerEBills.Commands.Update;

public class UpdateCustomerEBillCommand : IRequest<UpdatedCustomerEBillResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int EBillId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerEBillsOperationClaims.Update };

    public class UpdateCustomerEBillCommandHandler : IRequestHandler<UpdateCustomerEBillCommand, UpdatedCustomerEBillResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerEBillRepository _customerEBillRepository;
        private readonly CustomerEBillBusinessRules _customerEBillBusinessRules;

        public UpdateCustomerEBillCommandHandler(IMapper mapper, ICustomerEBillRepository customerEBillRepository,
                                         CustomerEBillBusinessRules customerEBillBusinessRules)
        {
            _mapper = mapper;
            _customerEBillRepository = customerEBillRepository;
            _customerEBillBusinessRules = customerEBillBusinessRules;
        }

        public async Task<UpdatedCustomerEBillResponse> Handle(UpdateCustomerEBillCommand request, CancellationToken cancellationToken)
        {
            CustomerEBill? customerEBill = await _customerEBillRepository.GetAsync(predicate: ceb => ceb.Id == request.Id, cancellationToken: cancellationToken);
            await _customerEBillBusinessRules.CustomerEBillShouldExistWhenSelected(customerEBill);
            customerEBill = _mapper.Map(request, customerEBill);

            await _customerEBillRepository.UpdateAsync(customerEBill!);

            UpdatedCustomerEBillResponse response = _mapper.Map<UpdatedCustomerEBillResponse>(customerEBill);
            return response;
        }
    }
}