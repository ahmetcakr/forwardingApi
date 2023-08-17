using Application.Features.CustomerCommercialTypes.Constants;
using Application.Features.CustomerCommercialTypes.Constants;
using Application.Features.CustomerCommercialTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerCommercialTypes.Constants.CustomerCommercialTypesOperationClaims;

namespace Application.Features.CustomerCommercialTypes.Commands.Delete;

public class DeleteCustomerCommercialTypeCommand : IRequest<DeletedCustomerCommercialTypeResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerCommercialTypesOperationClaims.Delete };

    public class DeleteCustomerCommercialTypeCommandHandler : IRequestHandler<DeleteCustomerCommercialTypeCommand, DeletedCustomerCommercialTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCommercialTypeRepository _customerCommercialTypeRepository;
        private readonly CustomerCommercialTypeBusinessRules _customerCommercialTypeBusinessRules;

        public DeleteCustomerCommercialTypeCommandHandler(IMapper mapper, ICustomerCommercialTypeRepository customerCommercialTypeRepository,
                                         CustomerCommercialTypeBusinessRules customerCommercialTypeBusinessRules)
        {
            _mapper = mapper;
            _customerCommercialTypeRepository = customerCommercialTypeRepository;
            _customerCommercialTypeBusinessRules = customerCommercialTypeBusinessRules;
        }

        public async Task<DeletedCustomerCommercialTypeResponse> Handle(DeleteCustomerCommercialTypeCommand request, CancellationToken cancellationToken)
        {
            CustomerCommercialType? customerCommercialType = await _customerCommercialTypeRepository.GetAsync(predicate: cct => cct.Id == request.Id, cancellationToken: cancellationToken);
            await _customerCommercialTypeBusinessRules.CustomerCommercialTypeShouldExistWhenSelected(customerCommercialType);

            await _customerCommercialTypeRepository.DeleteAsync(customerCommercialType!);

            DeletedCustomerCommercialTypeResponse response = _mapper.Map<DeletedCustomerCommercialTypeResponse>(customerCommercialType);
            return response;
        }
    }
}