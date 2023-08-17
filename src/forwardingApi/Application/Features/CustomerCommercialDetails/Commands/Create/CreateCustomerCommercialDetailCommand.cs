using Application.Features.CustomerCommercialDetails.Constants;
using Application.Features.CustomerCommercialDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerCommercialDetails.Constants.CustomerCommercialDetailsOperationClaims;

namespace Application.Features.CustomerCommercialDetails.Commands.Create;

public class CreateCustomerCommercialDetailCommand : IRequest<CreatedCustomerCommercialDetailResponse>, ISecuredRequest, ITransactionalRequest
{
    public int CustomerId { get; set; }
    public int CommercialDetailId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerCommercialDetailsOperationClaims.Create };

    public class CreateCustomerCommercialDetailCommandHandler : IRequestHandler<CreateCustomerCommercialDetailCommand, CreatedCustomerCommercialDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCommercialDetailRepository _customerCommercialDetailRepository;
        private readonly CustomerCommercialDetailBusinessRules _customerCommercialDetailBusinessRules;

        public CreateCustomerCommercialDetailCommandHandler(IMapper mapper, ICustomerCommercialDetailRepository customerCommercialDetailRepository,
                                         CustomerCommercialDetailBusinessRules customerCommercialDetailBusinessRules)
        {
            _mapper = mapper;
            _customerCommercialDetailRepository = customerCommercialDetailRepository;
            _customerCommercialDetailBusinessRules = customerCommercialDetailBusinessRules;
        }

        public async Task<CreatedCustomerCommercialDetailResponse> Handle(CreateCustomerCommercialDetailCommand request, CancellationToken cancellationToken)
        {
            CustomerCommercialDetail customerCommercialDetail = _mapper.Map<CustomerCommercialDetail>(request);

            await _customerCommercialDetailRepository.AddAsync(customerCommercialDetail);

            CreatedCustomerCommercialDetailResponse response = _mapper.Map<CreatedCustomerCommercialDetailResponse>(customerCommercialDetail);
            return response;
        }
    }
}