using Application.Features.CustomerCommercialTypes.Constants;
using Application.Features.CustomerCommercialTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerCommercialTypes.Constants.CustomerCommercialTypesOperationClaims;

namespace Application.Features.CustomerCommercialTypes.Commands.Create;

public class CreateCustomerCommercialTypeCommand : IRequest<CreatedCustomerCommercialTypeResponse>, ISecuredRequest, ITransactionalRequest
{
    public int CustomerId { get; set; }
    public int CommercialTypeId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerCommercialTypesOperationClaims.Create };

    public class CreateCustomerCommercialTypeCommandHandler : IRequestHandler<CreateCustomerCommercialTypeCommand, CreatedCustomerCommercialTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCommercialTypeRepository _customerCommercialTypeRepository;
        private readonly CustomerCommercialTypeBusinessRules _customerCommercialTypeBusinessRules;

        public CreateCustomerCommercialTypeCommandHandler(IMapper mapper, ICustomerCommercialTypeRepository customerCommercialTypeRepository,
                                         CustomerCommercialTypeBusinessRules customerCommercialTypeBusinessRules)
        {
            _mapper = mapper;
            _customerCommercialTypeRepository = customerCommercialTypeRepository;
            _customerCommercialTypeBusinessRules = customerCommercialTypeBusinessRules;
        }

        public async Task<CreatedCustomerCommercialTypeResponse> Handle(CreateCustomerCommercialTypeCommand request, CancellationToken cancellationToken)
        {
            CustomerCommercialType customerCommercialType = _mapper.Map<CustomerCommercialType>(request);

            await _customerCommercialTypeRepository.AddAsync(customerCommercialType);

            CreatedCustomerCommercialTypeResponse response = _mapper.Map<CreatedCustomerCommercialTypeResponse>(customerCommercialType);
            return response;
        }
    }
}