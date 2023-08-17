using Application.Features.CommercialTypes.Constants;
using Application.Features.CommercialTypes.Constants;
using Application.Features.CommercialTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CommercialTypes.Constants.CommercialTypesOperationClaims;

namespace Application.Features.CommercialTypes.Commands.Delete;

public class DeleteCommercialTypeCommand : IRequest<DeletedCommercialTypeResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CommercialTypesOperationClaims.Delete };

    public class DeleteCommercialTypeCommandHandler : IRequestHandler<DeleteCommercialTypeCommand, DeletedCommercialTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommercialTypeRepository _commercialTypeRepository;
        private readonly CommercialTypeBusinessRules _commercialTypeBusinessRules;

        public DeleteCommercialTypeCommandHandler(IMapper mapper, ICommercialTypeRepository commercialTypeRepository,
                                         CommercialTypeBusinessRules commercialTypeBusinessRules)
        {
            _mapper = mapper;
            _commercialTypeRepository = commercialTypeRepository;
            _commercialTypeBusinessRules = commercialTypeBusinessRules;
        }

        public async Task<DeletedCommercialTypeResponse> Handle(DeleteCommercialTypeCommand request, CancellationToken cancellationToken)
        {
            CommercialType? commercialType = await _commercialTypeRepository.GetAsync(predicate: ct => ct.Id == request.Id, cancellationToken: cancellationToken);
            await _commercialTypeBusinessRules.CommercialTypeShouldExistWhenSelected(commercialType);

            await _commercialTypeRepository.DeleteAsync(commercialType!);

            DeletedCommercialTypeResponse response = _mapper.Map<DeletedCommercialTypeResponse>(commercialType);
            return response;
        }
    }
}