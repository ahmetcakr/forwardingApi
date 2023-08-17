using Application.Features.CustomerSectors.Constants;
using Application.Features.CustomerSectors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerSectors.Constants.CustomerSectorsOperationClaims;

namespace Application.Features.CustomerSectors.Commands.Update;

public class UpdateCustomerSectorCommand : IRequest<UpdatedCustomerSectorResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int SectorId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerSectorsOperationClaims.Update };

    public class UpdateCustomerSectorCommandHandler : IRequestHandler<UpdateCustomerSectorCommand, UpdatedCustomerSectorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerSectorRepository _customerSectorRepository;
        private readonly CustomerSectorBusinessRules _customerSectorBusinessRules;

        public UpdateCustomerSectorCommandHandler(IMapper mapper, ICustomerSectorRepository customerSectorRepository,
                                         CustomerSectorBusinessRules customerSectorBusinessRules)
        {
            _mapper = mapper;
            _customerSectorRepository = customerSectorRepository;
            _customerSectorBusinessRules = customerSectorBusinessRules;
        }

        public async Task<UpdatedCustomerSectorResponse> Handle(UpdateCustomerSectorCommand request, CancellationToken cancellationToken)
        {
            CustomerSector? customerSector = await _customerSectorRepository.GetAsync(predicate: cs => cs.Id == request.Id, cancellationToken: cancellationToken);
            await _customerSectorBusinessRules.CustomerSectorShouldExistWhenSelected(customerSector);
            customerSector = _mapper.Map(request, customerSector);

            await _customerSectorRepository.UpdateAsync(customerSector!);

            UpdatedCustomerSectorResponse response = _mapper.Map<UpdatedCustomerSectorResponse>(customerSector);
            return response;
        }
    }
}