using Application.Features.CustomerFirmTypes.Constants;
using Application.Features.CustomerFirmTypes.Constants;
using Application.Features.CustomerFirmTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerFirmTypes.Constants.CustomerFirmTypesOperationClaims;

namespace Application.Features.CustomerFirmTypes.Commands.Delete;

public class DeleteCustomerFirmTypeCommand : IRequest<DeletedCustomerFirmTypeResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerFirmTypesOperationClaims.Delete };

    public class DeleteCustomerFirmTypeCommandHandler : IRequestHandler<DeleteCustomerFirmTypeCommand, DeletedCustomerFirmTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerFirmTypeRepository _customerFirmTypeRepository;
        private readonly CustomerFirmTypeBusinessRules _customerFirmTypeBusinessRules;

        public DeleteCustomerFirmTypeCommandHandler(IMapper mapper, ICustomerFirmTypeRepository customerFirmTypeRepository,
                                         CustomerFirmTypeBusinessRules customerFirmTypeBusinessRules)
        {
            _mapper = mapper;
            _customerFirmTypeRepository = customerFirmTypeRepository;
            _customerFirmTypeBusinessRules = customerFirmTypeBusinessRules;
        }

        public async Task<DeletedCustomerFirmTypeResponse> Handle(DeleteCustomerFirmTypeCommand request, CancellationToken cancellationToken)
        {
            CustomerFirmType? customerFirmType = await _customerFirmTypeRepository.GetAsync(predicate: cft => cft.Id == request.Id, cancellationToken: cancellationToken);
            await _customerFirmTypeBusinessRules.CustomerFirmTypeShouldExistWhenSelected(customerFirmType);

            await _customerFirmTypeRepository.DeleteAsync(customerFirmType!);

            DeletedCustomerFirmTypeResponse response = _mapper.Map<DeletedCustomerFirmTypeResponse>(customerFirmType);
            return response;
        }
    }
}