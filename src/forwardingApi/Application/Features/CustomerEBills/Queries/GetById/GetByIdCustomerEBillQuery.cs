using Application.Features.CustomerEBills.Constants;
using Application.Features.CustomerEBills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomerEBills.Constants.CustomerEBillsOperationClaims;

namespace Application.Features.CustomerEBills.Queries.GetById;

public class GetByIdCustomerEBillQuery : IRequest<GetByIdCustomerEBillResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCustomerEBillQueryHandler : IRequestHandler<GetByIdCustomerEBillQuery, GetByIdCustomerEBillResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerEBillRepository _customerEBillRepository;
        private readonly CustomerEBillBusinessRules _customerEBillBusinessRules;

        public GetByIdCustomerEBillQueryHandler(IMapper mapper, ICustomerEBillRepository customerEBillRepository, CustomerEBillBusinessRules customerEBillBusinessRules)
        {
            _mapper = mapper;
            _customerEBillRepository = customerEBillRepository;
            _customerEBillBusinessRules = customerEBillBusinessRules;
        }

        public async Task<GetByIdCustomerEBillResponse> Handle(GetByIdCustomerEBillQuery request, CancellationToken cancellationToken)
        {
            CustomerEBill? customerEBill = await _customerEBillRepository.GetAsync(predicate: ceb => ceb.Id == request.Id, cancellationToken: cancellationToken);
            await _customerEBillBusinessRules.CustomerEBillShouldExistWhenSelected(customerEBill);

            GetByIdCustomerEBillResponse response = _mapper.Map<GetByIdCustomerEBillResponse>(customerEBill);
            return response;
        }
    }
}