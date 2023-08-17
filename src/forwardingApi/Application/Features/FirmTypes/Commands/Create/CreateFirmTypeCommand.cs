using Application.Features.FirmTypes.Constants;
using Application.Features.FirmTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.FirmTypes.Constants.FirmTypesOperationClaims;

namespace Application.Features.FirmTypes.Commands.Create;

public class CreateFirmTypeCommand : IRequest<CreatedFirmTypeResponse>, ISecuredRequest, ITransactionalRequest
{
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, FirmTypesOperationClaims.Create };

    public class CreateFirmTypeCommandHandler : IRequestHandler<CreateFirmTypeCommand, CreatedFirmTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFirmTypeRepository _firmTypeRepository;
        private readonly FirmTypeBusinessRules _firmTypeBusinessRules;

        public CreateFirmTypeCommandHandler(IMapper mapper, IFirmTypeRepository firmTypeRepository,
                                         FirmTypeBusinessRules firmTypeBusinessRules)
        {
            _mapper = mapper;
            _firmTypeRepository = firmTypeRepository;
            _firmTypeBusinessRules = firmTypeBusinessRules;
        }

        public async Task<CreatedFirmTypeResponse> Handle(CreateFirmTypeCommand request, CancellationToken cancellationToken)
        {
            FirmType firmType = _mapper.Map<FirmType>(request);

            await _firmTypeRepository.AddAsync(firmType);

            CreatedFirmTypeResponse response = _mapper.Map<CreatedFirmTypeResponse>(firmType);
            return response;
        }
    }
}