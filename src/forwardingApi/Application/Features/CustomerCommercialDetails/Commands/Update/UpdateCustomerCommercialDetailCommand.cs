using Application.Features.CustomerCommercialDetails.Constants;
using Application.Features.CustomerCommercialDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerCommercialDetails.Constants.CustomerCommercialDetailsOperationClaims;

namespace Application.Features.CustomerCommercialDetails.Commands.Update;

public class UpdateCustomerCommercialDetailCommand : IRequest<UpdatedCustomerCommercialDetailResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CommercialDetailId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerCommercialDetailsOperationClaims.Update };

    public class UpdateCustomerCommercialDetailCommandHandler : IRequestHandler<UpdateCustomerCommercialDetailCommand, UpdatedCustomerCommercialDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCommercialDetailRepository _customerCommercialDetailRepository;
        private readonly CustomerCommercialDetailBusinessRules _customerCommercialDetailBusinessRules;

        public UpdateCustomerCommercialDetailCommandHandler(IMapper mapper, ICustomerCommercialDetailRepository customerCommercialDetailRepository,
                                         CustomerCommercialDetailBusinessRules customerCommercialDetailBusinessRules)
        {
            _mapper = mapper;
            _customerCommercialDetailRepository = customerCommercialDetailRepository;
            _customerCommercialDetailBusinessRules = customerCommercialDetailBusinessRules;
        }

        public async Task<UpdatedCustomerCommercialDetailResponse> Handle(UpdateCustomerCommercialDetailCommand request, CancellationToken cancellationToken)
        {
            CustomerCommercialDetail? customerCommercialDetail = await _customerCommercialDetailRepository.GetAsync(predicate: ccd => ccd.Id == request.Id, cancellationToken: cancellationToken);
            await _customerCommercialDetailBusinessRules.CustomerCommercialDetailShouldExistWhenSelected(customerCommercialDetail);
            customerCommercialDetail = _mapper.Map(request, customerCommercialDetail);

            await _customerCommercialDetailRepository.UpdateAsync(customerCommercialDetail!);

            UpdatedCustomerCommercialDetailResponse response = _mapper.Map<UpdatedCustomerCommercialDetailResponse>(customerCommercialDetail);
            return response;
        }
    }
}