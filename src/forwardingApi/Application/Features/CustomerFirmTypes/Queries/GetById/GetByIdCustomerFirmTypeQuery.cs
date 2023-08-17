using Application.Features.CustomerFirmTypes.Constants;
using Application.Features.CustomerFirmTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomerFirmTypes.Constants.CustomerFirmTypesOperationClaims;

namespace Application.Features.CustomerFirmTypes.Queries.GetById;

public class GetByIdCustomerFirmTypeQuery : IRequest<GetByIdCustomerFirmTypeResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCustomerFirmTypeQueryHandler : IRequestHandler<GetByIdCustomerFirmTypeQuery, GetByIdCustomerFirmTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerFirmTypeRepository _customerFirmTypeRepository;
        private readonly CustomerFirmTypeBusinessRules _customerFirmTypeBusinessRules;

        public GetByIdCustomerFirmTypeQueryHandler(IMapper mapper, ICustomerFirmTypeRepository customerFirmTypeRepository, CustomerFirmTypeBusinessRules customerFirmTypeBusinessRules)
        {
            _mapper = mapper;
            _customerFirmTypeRepository = customerFirmTypeRepository;
            _customerFirmTypeBusinessRules = customerFirmTypeBusinessRules;
        }

        public async Task<GetByIdCustomerFirmTypeResponse> Handle(GetByIdCustomerFirmTypeQuery request, CancellationToken cancellationToken)
        {
            CustomerFirmType? customerFirmType = await _customerFirmTypeRepository.GetAsync(predicate: cft => cft.Id == request.Id, cancellationToken: cancellationToken);
            await _customerFirmTypeBusinessRules.CustomerFirmTypeShouldExistWhenSelected(customerFirmType);

            GetByIdCustomerFirmTypeResponse response = _mapper.Map<GetByIdCustomerFirmTypeResponse>(customerFirmType);
            return response;
        }
    }
}