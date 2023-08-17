using Application.Features.CustomerCommercialTypes.Constants;
using Application.Features.CustomerCommercialTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerCommercialTypes.Constants.CustomerCommercialTypesOperationClaims;

namespace Application.Features.CustomerCommercialTypes.Commands.Update;

public class UpdateCustomerCommercialTypeCommand : IRequest<UpdatedCustomerCommercialTypeResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CommercialTypeId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerCommercialTypesOperationClaims.Update };

    public class UpdateCustomerCommercialTypeCommandHandler : IRequestHandler<UpdateCustomerCommercialTypeCommand, UpdatedCustomerCommercialTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCommercialTypeRepository _customerCommercialTypeRepository;
        private readonly CustomerCommercialTypeBusinessRules _customerCommercialTypeBusinessRules;

        public UpdateCustomerCommercialTypeCommandHandler(IMapper mapper, ICustomerCommercialTypeRepository customerCommercialTypeRepository,
                                         CustomerCommercialTypeBusinessRules customerCommercialTypeBusinessRules)
        {
            _mapper = mapper;
            _customerCommercialTypeRepository = customerCommercialTypeRepository;
            _customerCommercialTypeBusinessRules = customerCommercialTypeBusinessRules;
        }

        public async Task<UpdatedCustomerCommercialTypeResponse> Handle(UpdateCustomerCommercialTypeCommand request, CancellationToken cancellationToken)
        {
            CustomerCommercialType? customerCommercialType = await _customerCommercialTypeRepository.GetAsync(predicate: cct => cct.Id == request.Id, cancellationToken: cancellationToken);
            await _customerCommercialTypeBusinessRules.CustomerCommercialTypeShouldExistWhenSelected(customerCommercialType);
            customerCommercialType = _mapper.Map(request, customerCommercialType);

            await _customerCommercialTypeRepository.UpdateAsync(customerCommercialType!);

            UpdatedCustomerCommercialTypeResponse response = _mapper.Map<UpdatedCustomerCommercialTypeResponse>(customerCommercialType);
            return response;
        }
    }
}