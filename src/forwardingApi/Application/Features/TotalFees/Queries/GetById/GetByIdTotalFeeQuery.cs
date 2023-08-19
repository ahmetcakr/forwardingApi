using Application.Features.TotalFees.Constants;
using Application.Features.TotalFees.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.TotalFees.Constants.TotalFeesOperationClaims;

namespace Application.Features.TotalFees.Queries.GetById;

public class GetByIdTotalFeeQuery : IRequest<GetByIdTotalFeeResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdTotalFeeQueryHandler : IRequestHandler<GetByIdTotalFeeQuery, GetByIdTotalFeeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITotalFeeRepository _totalFeeRepository;
        private readonly TotalFeeBusinessRules _totalFeeBusinessRules;

        public GetByIdTotalFeeQueryHandler(IMapper mapper, ITotalFeeRepository totalFeeRepository, TotalFeeBusinessRules totalFeeBusinessRules)
        {
            _mapper = mapper;
            _totalFeeRepository = totalFeeRepository;
            _totalFeeBusinessRules = totalFeeBusinessRules;
        }

        public async Task<GetByIdTotalFeeResponse> Handle(GetByIdTotalFeeQuery request, CancellationToken cancellationToken)
        {
            TotalFee? totalFee = await _totalFeeRepository.GetAsync(predicate: tf => tf.Id == request.Id, cancellationToken: cancellationToken);
            await _totalFeeBusinessRules.TotalFeeShouldExistWhenSelected(totalFee);

            GetByIdTotalFeeResponse response = _mapper.Map<GetByIdTotalFeeResponse>(totalFee);
            return response;
        }
    }
}