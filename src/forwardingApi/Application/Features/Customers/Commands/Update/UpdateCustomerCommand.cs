using Application.Features.Customers.Constants;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Customers.Constants.CustomersOperationClaims;

namespace Application.Features.Customers.Commands.Update;

public class UpdateCustomerCommand : IRequest<UpdatedCustomerResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
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

    public string[] Roles => new[] { Admin, Write, CustomersOperationClaims.Update };

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdatedCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerBusinessRules _customerBusinessRules;

        public UpdateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository,
                                         CustomerBusinessRules customerBusinessRules)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _customerBusinessRules = customerBusinessRules;
        }

        public async Task<UpdatedCustomerResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer? customer = await _customerRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _customerBusinessRules.CustomerShouldExistWhenSelected(customer);
            customer = _mapper.Map(request, customer);

            await _customerRepository.UpdateAsync(customer!);

            UpdatedCustomerResponse response = _mapper.Map<UpdatedCustomerResponse>(customer);
            return response;
        }
    }
}