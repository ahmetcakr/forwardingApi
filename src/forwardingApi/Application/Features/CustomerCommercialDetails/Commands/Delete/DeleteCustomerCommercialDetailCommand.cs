using Application.Features.CustomerCommercialDetails.Constants;
using Application.Features.CustomerCommercialDetails.Constants;
using Application.Features.CustomerCommercialDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerCommercialDetails.Constants.CustomerCommercialDetailsOperationClaims;

namespace Application.Features.CustomerCommercialDetails.Commands.Delete;

public class DeleteCustomerCommercialDetailCommand : IRequest<DeletedCustomerCommercialDetailResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerCommercialDetailsOperationClaims.Delete };

    public class DeleteCustomerCommercialDetailCommandHandler : IRequestHandler<DeleteCustomerCommercialDetailCommand, DeletedCustomerCommercialDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCommercialDetailRepository _customerCommercialDetailRepository;
        private readonly CustomerCommercialDetailBusinessRules _customerCommercialDetailBusinessRules;

        public DeleteCustomerCommercialDetailCommandHandler(IMapper mapper, ICustomerCommercialDetailRepository customerCommercialDetailRepository,
                                         CustomerCommercialDetailBusinessRules customerCommercialDetailBusinessRules)
        {
            _mapper = mapper;
            _customerCommercialDetailRepository = customerCommercialDetailRepository;
            _customerCommercialDetailBusinessRules = customerCommercialDetailBusinessRules;
        }

        public async Task<DeletedCustomerCommercialDetailResponse> Handle(DeleteCustomerCommercialDetailCommand request, CancellationToken cancellationToken)
        {
            CustomerCommercialDetail? customerCommercialDetail = await _customerCommercialDetailRepository.GetAsync(predicate: ccd => ccd.Id == request.Id, cancellationToken: cancellationToken);
            await _customerCommercialDetailBusinessRules.CustomerCommercialDetailShouldExistWhenSelected(customerCommercialDetail);

            await _customerCommercialDetailRepository.DeleteAsync(customerCommercialDetail!);

            DeletedCustomerCommercialDetailResponse response = _mapper.Map<DeletedCustomerCommercialDetailResponse>(customerCommercialDetail);
            return response;
        }
    }
}