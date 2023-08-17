using Application.Features.CustomerSectors.Constants;
using Application.Features.CustomerSectors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerSectors.Constants.CustomerSectorsOperationClaims;

namespace Application.Features.CustomerSectors.Commands.Create;

public class CreateCustomerSectorCommand : IRequest<CreatedCustomerSectorResponse>, ISecuredRequest, ITransactionalRequest
{
    public int CustomerId { get; set; }
    public int SectorId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerSectorsOperationClaims.Create };

    public class CreateCustomerSectorCommandHandler : IRequestHandler<CreateCustomerSectorCommand, CreatedCustomerSectorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerSectorRepository _customerSectorRepository;
        private readonly CustomerSectorBusinessRules _customerSectorBusinessRules;

        public CreateCustomerSectorCommandHandler(IMapper mapper, ICustomerSectorRepository customerSectorRepository,
                                         CustomerSectorBusinessRules customerSectorBusinessRules)
        {
            _mapper = mapper;
            _customerSectorRepository = customerSectorRepository;
            _customerSectorBusinessRules = customerSectorBusinessRules;
        }

        public async Task<CreatedCustomerSectorResponse> Handle(CreateCustomerSectorCommand request, CancellationToken cancellationToken)
        {
            CustomerSector customerSector = _mapper.Map<CustomerSector>(request);

            await _customerSectorRepository.AddAsync(customerSector);

            CreatedCustomerSectorResponse response = _mapper.Map<CreatedCustomerSectorResponse>(customerSector);
            return response;
        }
    }
}