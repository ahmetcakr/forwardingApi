using Application.Features.FirmTypes.Constants;
using Application.Features.FirmTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.FirmTypes.Constants.FirmTypesOperationClaims;

namespace Application.Features.FirmTypes.Commands.Update;

public class UpdateFirmTypeCommand : IRequest<UpdatedFirmTypeResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, FirmTypesOperationClaims.Update };

    public class UpdateFirmTypeCommandHandler : IRequestHandler<UpdateFirmTypeCommand, UpdatedFirmTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFirmTypeRepository _firmTypeRepository;
        private readonly FirmTypeBusinessRules _firmTypeBusinessRules;

        public UpdateFirmTypeCommandHandler(IMapper mapper, IFirmTypeRepository firmTypeRepository,
                                         FirmTypeBusinessRules firmTypeBusinessRules)
        {
            _mapper = mapper;
            _firmTypeRepository = firmTypeRepository;
            _firmTypeBusinessRules = firmTypeBusinessRules;
        }

        public async Task<UpdatedFirmTypeResponse> Handle(UpdateFirmTypeCommand request, CancellationToken cancellationToken)
        {
            FirmType? firmType = await _firmTypeRepository.GetAsync(predicate: ft => ft.Id == request.Id, cancellationToken: cancellationToken);
            await _firmTypeBusinessRules.FirmTypeShouldExistWhenSelected(firmType);
            firmType = _mapper.Map(request, firmType);

            await _firmTypeRepository.UpdateAsync(firmType!);

            UpdatedFirmTypeResponse response = _mapper.Map<UpdatedFirmTypeResponse>(firmType);
            return response;
        }
    }
}