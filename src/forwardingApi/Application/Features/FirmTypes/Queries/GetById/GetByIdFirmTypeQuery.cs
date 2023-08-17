using Application.Features.FirmTypes.Constants;
using Application.Features.FirmTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.FirmTypes.Constants.FirmTypesOperationClaims;

namespace Application.Features.FirmTypes.Queries.GetById;

public class GetByIdFirmTypeQuery : IRequest<GetByIdFirmTypeResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdFirmTypeQueryHandler : IRequestHandler<GetByIdFirmTypeQuery, GetByIdFirmTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFirmTypeRepository _firmTypeRepository;
        private readonly FirmTypeBusinessRules _firmTypeBusinessRules;

        public GetByIdFirmTypeQueryHandler(IMapper mapper, IFirmTypeRepository firmTypeRepository, FirmTypeBusinessRules firmTypeBusinessRules)
        {
            _mapper = mapper;
            _firmTypeRepository = firmTypeRepository;
            _firmTypeBusinessRules = firmTypeBusinessRules;
        }

        public async Task<GetByIdFirmTypeResponse> Handle(GetByIdFirmTypeQuery request, CancellationToken cancellationToken)
        {
            FirmType? firmType = await _firmTypeRepository.GetAsync(predicate: ft => ft.Id == request.Id, cancellationToken: cancellationToken);
            await _firmTypeBusinessRules.FirmTypeShouldExistWhenSelected(firmType);

            GetByIdFirmTypeResponse response = _mapper.Map<GetByIdFirmTypeResponse>(firmType);
            return response;
        }
    }
}