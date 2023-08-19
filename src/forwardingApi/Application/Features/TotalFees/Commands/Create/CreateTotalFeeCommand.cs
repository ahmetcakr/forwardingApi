using Application.Features.TotalFees.Constants;
using Application.Features.TotalFees.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.TotalFees.Constants.TotalFeesOperationClaims;

namespace Application.Features.TotalFees.Commands.Create;

public class CreateTotalFeeCommand : IRequest<CreatedTotalFeeResponse>, ISecuredRequest, ITransactionalRequest
{
    public int? Fee { get; set; }
    public int? Vat { get; set; }
    public int? Total { get; set; }

    public string[] Roles => new[] { Admin, Write, TotalFeesOperationClaims.Create };

    public class CreateTotalFeeCommandHandler : IRequestHandler<CreateTotalFeeCommand, CreatedTotalFeeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITotalFeeRepository _totalFeeRepository;
        private readonly TotalFeeBusinessRules _totalFeeBusinessRules;

        public CreateTotalFeeCommandHandler(IMapper mapper, ITotalFeeRepository totalFeeRepository,
                                         TotalFeeBusinessRules totalFeeBusinessRules)
        {
            _mapper = mapper;
            _totalFeeRepository = totalFeeRepository;
            _totalFeeBusinessRules = totalFeeBusinessRules;
        }

        public async Task<CreatedTotalFeeResponse> Handle(CreateTotalFeeCommand request, CancellationToken cancellationToken)
        {
            TotalFee totalFee = _mapper.Map<TotalFee>(request);

            await _totalFeeRepository.AddAsync(totalFee);

            CreatedTotalFeeResponse response = _mapper.Map<CreatedTotalFeeResponse>(totalFee);
            return response;
        }
    }
}