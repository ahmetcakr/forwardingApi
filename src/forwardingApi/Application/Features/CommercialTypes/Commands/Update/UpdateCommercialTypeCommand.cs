using Application.Features.CommercialTypes.Constants;
using Application.Features.CommercialTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CommercialTypes.Constants.CommercialTypesOperationClaims;

namespace Application.Features.CommercialTypes.Commands.Update;

public class UpdateCommercialTypeCommand : IRequest<UpdatedCommercialTypeResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, CommercialTypesOperationClaims.Update };

    public class UpdateCommercialTypeCommandHandler : IRequestHandler<UpdateCommercialTypeCommand, UpdatedCommercialTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommercialTypeRepository _commercialTypeRepository;
        private readonly CommercialTypeBusinessRules _commercialTypeBusinessRules;

        public UpdateCommercialTypeCommandHandler(IMapper mapper, ICommercialTypeRepository commercialTypeRepository,
                                         CommercialTypeBusinessRules commercialTypeBusinessRules)
        {
            _mapper = mapper;
            _commercialTypeRepository = commercialTypeRepository;
            _commercialTypeBusinessRules = commercialTypeBusinessRules;
        }

        public async Task<UpdatedCommercialTypeResponse> Handle(UpdateCommercialTypeCommand request, CancellationToken cancellationToken)
        {
            CommercialType? commercialType = await _commercialTypeRepository.GetAsync(predicate: ct => ct.Id == request.Id, cancellationToken: cancellationToken);
            await _commercialTypeBusinessRules.CommercialTypeShouldExistWhenSelected(commercialType);
            commercialType = _mapper.Map(request, commercialType);

            await _commercialTypeRepository.UpdateAsync(commercialType!);

            UpdatedCommercialTypeResponse response = _mapper.Map<UpdatedCommercialTypeResponse>(commercialType);
            return response;
        }
    }
}