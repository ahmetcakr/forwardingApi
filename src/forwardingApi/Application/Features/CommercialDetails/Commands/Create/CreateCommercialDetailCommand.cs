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

namespace Application.Features.CommercialDetails.Commands.Create;

public class CreateCommercialDetailCommand : IRequest<CreatedCommercialDetailResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string? TaxOffice { get; set; }
    public string? TaxOfficeNo { get; set; }
    public string? Bank { get; set; }
    public string? BankAccountNo { get; set; }
    public string? BankDetail { get; set; }

    public string[] Roles => new[] { Admin, Write, CommercialDetailsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCommercialDetails";

    public class CreateCommercialDetailCommandHandler : IRequestHandler<CreateCommercialDetailCommand, CreatedCommercialDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommercialDetailRepository _commercialDetailRepository;
        private readonly CommercialDetailBusinessRules _commercialDetailBusinessRules;

        public CreateCommercialDetailCommandHandler(IMapper mapper, ICommercialDetailRepository commercialDetailRepository,
                                         CommercialDetailBusinessRules commercialDetailBusinessRules)
        {
            _mapper = mapper;
            _commercialDetailRepository = commercialDetailRepository;
            _commercialDetailBusinessRules = commercialDetailBusinessRules;
        }

        public async Task<CreatedCommercialDetailResponse> Handle(CreateCommercialDetailCommand request, CancellationToken cancellationToken)
        {
            CommercialDetail commercialDetail = _mapper.Map<CommercialDetail>(request);

            await _commercialDetailRepository.AddAsync(commercialDetail);

            CreatedCommercialDetailResponse response = _mapper.Map<CreatedCommercialDetailResponse>(commercialDetail);
            return response;
        }
    }
}