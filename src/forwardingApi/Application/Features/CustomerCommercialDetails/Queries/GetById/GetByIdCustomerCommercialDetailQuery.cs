using Application.Features.CustomerCommercialDetails.Constants;
using Application.Features.CustomerCommercialDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomerCommercialDetails.Constants.CustomerCommercialDetailsOperationClaims;

namespace Application.Features.CustomerCommercialDetails.Queries.GetById;

public class GetByIdCustomerCommercialDetailQuery : IRequest<GetByIdCustomerCommercialDetailResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCustomerCommercialDetailQueryHandler : IRequestHandler<GetByIdCustomerCommercialDetailQuery, GetByIdCustomerCommercialDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCommercialDetailRepository _customerCommercialDetailRepository;
        private readonly CustomerCommercialDetailBusinessRules _customerCommercialDetailBusinessRules;

        public GetByIdCustomerCommercialDetailQueryHandler(IMapper mapper, ICustomerCommercialDetailRepository customerCommercialDetailRepository, CustomerCommercialDetailBusinessRules customerCommercialDetailBusinessRules)
        {
            _mapper = mapper;
            _customerCommercialDetailRepository = customerCommercialDetailRepository;
            _customerCommercialDetailBusinessRules = customerCommercialDetailBusinessRules;
        }

        public async Task<GetByIdCustomerCommercialDetailResponse> Handle(GetByIdCustomerCommercialDetailQuery request, CancellationToken cancellationToken)
        {
            CustomerCommercialDetail? customerCommercialDetail = await _customerCommercialDetailRepository.GetAsync(predicate: ccd => ccd.Id == request.Id, cancellationToken: cancellationToken);
            await _customerCommercialDetailBusinessRules.CustomerCommercialDetailShouldExistWhenSelected(customerCommercialDetail);

            GetByIdCustomerCommercialDetailResponse response = _mapper.Map<GetByIdCustomerCommercialDetailResponse>(customerCommercialDetail);
            return response;
        }
    }
}