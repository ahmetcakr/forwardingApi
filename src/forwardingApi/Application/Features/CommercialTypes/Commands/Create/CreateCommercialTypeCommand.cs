using Application.Features.CommercialTypes.Constants;
using Application.Features.CommercialTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CommercialTypes.Constants.CommercialTypesOperationClaims;

namespace Application.Features.CommercialTypes.Commands.Create;

public class CreateCommercialTypeCommand : IRequest<CreatedCommercialTypeResponse>, ISecuredRequest, ITransactionalRequest
{
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, CommercialTypesOperationClaims.Create };

    public class CreateCommercialTypeCommandHandler : IRequestHandler<CreateCommercialTypeCommand, CreatedCommercialTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommercialTypeRepository _commercialTypeRepository;
        private readonly CommercialTypeBusinessRules _commercialTypeBusinessRules;

        public CreateCommercialTypeCommandHandler(IMapper mapper, ICommercialTypeRepository commercialTypeRepository,
                                         CommercialTypeBusinessRules commercialTypeBusinessRules)
        {
            _mapper = mapper;
            _commercialTypeRepository = commercialTypeRepository;
            _commercialTypeBusinessRules = commercialTypeBusinessRules;
        }

        public async Task<CreatedCommercialTypeResponse> Handle(CreateCommercialTypeCommand request, CancellationToken cancellationToken)
        {
            CommercialType commercialType = _mapper.Map<CommercialType>(request);

            await _commercialTypeRepository.AddAsync(commercialType);

            CreatedCommercialTypeResponse response = _mapper.Map<CreatedCommercialTypeResponse>(commercialType);
            return response;
        }
    }
}