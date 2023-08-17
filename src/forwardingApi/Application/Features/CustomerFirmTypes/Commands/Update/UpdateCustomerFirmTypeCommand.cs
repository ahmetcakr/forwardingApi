using Application.Features.CustomerFirmTypes.Constants;
using Application.Features.CustomerFirmTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerFirmTypes.Constants.CustomerFirmTypesOperationClaims;

namespace Application.Features.CustomerFirmTypes.Commands.Update;

public class UpdateCustomerFirmTypeCommand : IRequest<UpdatedCustomerFirmTypeResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int FirmTypeId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerFirmTypesOperationClaims.Update };

    public class UpdateCustomerFirmTypeCommandHandler : IRequestHandler<UpdateCustomerFirmTypeCommand, UpdatedCustomerFirmTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerFirmTypeRepository _customerFirmTypeRepository;
        private readonly CustomerFirmTypeBusinessRules _customerFirmTypeBusinessRules;

        public UpdateCustomerFirmTypeCommandHandler(IMapper mapper, ICustomerFirmTypeRepository customerFirmTypeRepository,
                                         CustomerFirmTypeBusinessRules customerFirmTypeBusinessRules)
        {
            _mapper = mapper;
            _customerFirmTypeRepository = customerFirmTypeRepository;
            _customerFirmTypeBusinessRules = customerFirmTypeBusinessRules;
        }

        public async Task<UpdatedCustomerFirmTypeResponse> Handle(UpdateCustomerFirmTypeCommand request, CancellationToken cancellationToken)
        {
            CustomerFirmType? customerFirmType = await _customerFirmTypeRepository.GetAsync(predicate: cft => cft.Id == request.Id, cancellationToken: cancellationToken);
            await _customerFirmTypeBusinessRules.CustomerFirmTypeShouldExistWhenSelected(customerFirmType);
            customerFirmType = _mapper.Map(request, customerFirmType);

            await _customerFirmTypeRepository.UpdateAsync(customerFirmType!);

            UpdatedCustomerFirmTypeResponse response = _mapper.Map<UpdatedCustomerFirmTypeResponse>(customerFirmType);
            return response;
        }
    }
}