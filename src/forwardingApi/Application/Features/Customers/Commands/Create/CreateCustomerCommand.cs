using Application.Features.Customers.Constants;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Customers.Constants.CustomersOperationClaims;

namespace Application.Features.Customers.Commands.Create;

public class CreateCustomerCommand : IRequest<CreatedCustomerResponse>, ISecuredRequest, ITransactionalRequest
{
    public string? CustomerCode { get; set; }
    public string? CustomerName { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Region { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? Mail { get; set; }
    public int? CommercialDetailId { get; set; }
    public int? CommercialTypeId { get; set; }
    public int? EBillId { get; set; }
    public int? FirmTypeId { get; set; }
    public int? GroupId { get; set; }
    public int? SectorId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomersOperationClaims.Create };

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreatedCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerBusinessRules _customerBusinessRules;

        public CreateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository,
                                         CustomerBusinessRules customerBusinessRules)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _customerBusinessRules = customerBusinessRules;
        }

        public async Task<CreatedCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = _mapper.Map<Customer>(request);

            await _customerRepository.AddAsync(customer);

            CreatedCustomerResponse response = _mapper.Map<CreatedCustomerResponse>(customer);
            return response;
        }
    }
}