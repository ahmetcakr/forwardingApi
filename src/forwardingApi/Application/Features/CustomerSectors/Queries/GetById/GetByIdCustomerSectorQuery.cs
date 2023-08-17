using Application.Features.CustomerSectors.Constants;
using Application.Features.CustomerSectors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomerSectors.Constants.CustomerSectorsOperationClaims;

namespace Application.Features.CustomerSectors.Queries.GetById;

public class GetByIdCustomerSectorQuery : IRequest<GetByIdCustomerSectorResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCustomerSectorQueryHandler : IRequestHandler<GetByIdCustomerSectorQuery, GetByIdCustomerSectorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerSectorRepository _customerSectorRepository;
        private readonly CustomerSectorBusinessRules _customerSectorBusinessRules;

        public GetByIdCustomerSectorQueryHandler(IMapper mapper, ICustomerSectorRepository customerSectorRepository, CustomerSectorBusinessRules customerSectorBusinessRules)
        {
            _mapper = mapper;
            _customerSectorRepository = customerSectorRepository;
            _customerSectorBusinessRules = customerSectorBusinessRules;
        }

        public async Task<GetByIdCustomerSectorResponse> Handle(GetByIdCustomerSectorQuery request, CancellationToken cancellationToken)
        {
            CustomerSector? customerSector = await _customerSectorRepository.GetAsync(predicate: cs => cs.Id == request.Id, cancellationToken: cancellationToken);
            await _customerSectorBusinessRules.CustomerSectorShouldExistWhenSelected(customerSector);

            GetByIdCustomerSectorResponse response = _mapper.Map<GetByIdCustomerSectorResponse>(customerSector);
            return response;
        }
    }
}