using Application.Features.CustomerFirmTypes.Constants;
using Application.Features.CustomerFirmTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerFirmTypes.Constants.CustomerFirmTypesOperationClaims;

namespace Application.Features.CustomerFirmTypes.Commands.Create;

public class CreateCustomerFirmTypeCommand : IRequest<CreatedCustomerFirmTypeResponse>, ISecuredRequest, ITransactionalRequest
{
    public int CustomerId { get; set; }
    public int FirmTypeId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerFirmTypesOperationClaims.Create };

    public class CreateCustomerFirmTypeCommandHandler : IRequestHandler<CreateCustomerFirmTypeCommand, CreatedCustomerFirmTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerFirmTypeRepository _customerFirmTypeRepository;
        private readonly CustomerFirmTypeBusinessRules _customerFirmTypeBusinessRules;

        public CreateCustomerFirmTypeCommandHandler(IMapper mapper, ICustomerFirmTypeRepository customerFirmTypeRepository,
                                         CustomerFirmTypeBusinessRules customerFirmTypeBusinessRules)
        {
            _mapper = mapper;
            _customerFirmTypeRepository = customerFirmTypeRepository;
            _customerFirmTypeBusinessRules = customerFirmTypeBusinessRules;
        }

        public async Task<CreatedCustomerFirmTypeResponse> Handle(CreateCustomerFirmTypeCommand request, CancellationToken cancellationToken)
        {
            CustomerFirmType customerFirmType = _mapper.Map<CustomerFirmType>(request);

            await _customerFirmTypeRepository.AddAsync(customerFirmType);

            CreatedCustomerFirmTypeResponse response = _mapper.Map<CreatedCustomerFirmTypeResponse>(customerFirmType);
            return response;
        }
    }
}