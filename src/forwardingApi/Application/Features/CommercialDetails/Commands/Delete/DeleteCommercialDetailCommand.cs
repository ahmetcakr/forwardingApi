using Application.Features.CommercialDetails.Constants;
using Application.Features.CommercialDetails.Constants;
using Application.Features.CommercialDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CommercialDetails.Constants.CommercialDetailsOperationClaims;

namespace Application.Features.CommercialDetails.Commands.Delete;

public class DeleteCommercialDetailCommand : IRequest<DeletedCommercialDetailResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CommercialDetailsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCommercialDetails";

    public class DeleteCommercialDetailCommandHandler : IRequestHandler<DeleteCommercialDetailCommand, DeletedCommercialDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommercialDetailRepository _commercialDetailRepository;
        private readonly CommercialDetailBusinessRules _commercialDetailBusinessRules;

        public DeleteCommercialDetailCommandHandler(IMapper mapper, ICommercialDetailRepository commercialDetailRepository,
                                         CommercialDetailBusinessRules commercialDetailBusinessRules)
        {
            _mapper = mapper;
            _commercialDetailRepository = commercialDetailRepository;
            _commercialDetailBusinessRules = commercialDetailBusinessRules;
        }

        public async Task<DeletedCommercialDetailResponse> Handle(DeleteCommercialDetailCommand request, CancellationToken cancellationToken)
        {
            CommercialDetail? commercialDetail = await _commercialDetailRepository.GetAsync(predicate: cd => cd.Id == request.Id, cancellationToken: cancellationToken);
            await _commercialDetailBusinessRules.CommercialDetailShouldExistWhenSelected(commercialDetail);

            await _commercialDetailRepository.DeleteAsync(commercialDetail!);

            DeletedCommercialDetailResponse response = _mapper.Map<DeletedCommercialDetailResponse>(commercialDetail);
            return response;
        }
    }
}