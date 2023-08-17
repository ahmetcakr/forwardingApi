using Application.Features.FirmTypes.Constants;
using Application.Features.FirmTypes.Constants;
using Application.Features.FirmTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.FirmTypes.Constants.FirmTypesOperationClaims;

namespace Application.Features.FirmTypes.Commands.Delete;

public class DeleteFirmTypeCommand : IRequest<DeletedFirmTypeResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, FirmTypesOperationClaims.Delete };

    public class DeleteFirmTypeCommandHandler : IRequestHandler<DeleteFirmTypeCommand, DeletedFirmTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFirmTypeRepository _firmTypeRepository;
        private readonly FirmTypeBusinessRules _firmTypeBusinessRules;

        public DeleteFirmTypeCommandHandler(IMapper mapper, IFirmTypeRepository firmTypeRepository,
                                         FirmTypeBusinessRules firmTypeBusinessRules)
        {
            _mapper = mapper;
            _firmTypeRepository = firmTypeRepository;
            _firmTypeBusinessRules = firmTypeBusinessRules;
        }

        public async Task<DeletedFirmTypeResponse> Handle(DeleteFirmTypeCommand request, CancellationToken cancellationToken)
        {
            FirmType? firmType = await _firmTypeRepository.GetAsync(predicate: ft => ft.Id == request.Id, cancellationToken: cancellationToken);
            await _firmTypeBusinessRules.FirmTypeShouldExistWhenSelected(firmType);

            await _firmTypeRepository.DeleteAsync(firmType!);

            DeletedFirmTypeResponse response = _mapper.Map<DeletedFirmTypeResponse>(firmType);
            return response;
        }
    }
}