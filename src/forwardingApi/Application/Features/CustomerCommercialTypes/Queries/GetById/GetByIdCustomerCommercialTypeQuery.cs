using Application.Features.CustomerCommercialTypes.Constants;
using Application.Features.CustomerCommercialTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomerCommercialTypes.Constants.CustomerCommercialTypesOperationClaims;

namespace Application.Features.CustomerCommercialTypes.Queries.GetById;

public class GetByIdCustomerCommercialTypeQuery : IRequest<GetByIdCustomerCommercialTypeResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCustomerCommercialTypeQueryHandler : IRequestHandler<GetByIdCustomerCommercialTypeQuery, GetByIdCustomerCommercialTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCommercialTypeRepository _customerCommercialTypeRepository;
        private readonly CustomerCommercialTypeBusinessRules _customerCommercialTypeBusinessRules;

        public GetByIdCustomerCommercialTypeQueryHandler(IMapper mapper, ICustomerCommercialTypeRepository customerCommercialTypeRepository, CustomerCommercialTypeBusinessRules customerCommercialTypeBusinessRules)
        {
            _mapper = mapper;
            _customerCommercialTypeRepository = customerCommercialTypeRepository;
            _customerCommercialTypeBusinessRules = customerCommercialTypeBusinessRules;
        }

        public async Task<GetByIdCustomerCommercialTypeResponse> Handle(GetByIdCustomerCommercialTypeQuery request, CancellationToken cancellationToken)
        {
            CustomerCommercialType? customerCommercialType = await _customerCommercialTypeRepository.GetAsync(predicate: cct => cct.Id == request.Id, cancellationToken: cancellationToken);
            await _customerCommercialTypeBusinessRules.CustomerCommercialTypeShouldExistWhenSelected(customerCommercialType);

            GetByIdCustomerCommercialTypeResponse response = _mapper.Map<GetByIdCustomerCommercialTypeResponse>(customerCommercialType);
            return response;
        }
    }
}