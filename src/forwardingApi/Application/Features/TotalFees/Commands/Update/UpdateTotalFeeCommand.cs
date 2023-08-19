using Application.Features.TotalFees.Constants;
using Application.Features.TotalFees.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.TotalFees.Constants.TotalFeesOperationClaims;

namespace Application.Features.TotalFees.Commands.Update;

public class UpdateTotalFeeCommand : IRequest<UpdatedTotalFeeResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int? Fee { get; set; }
    public int? Vat { get; set; }
    public int? Total { get; set; }

    public string[] Roles => new[] { Admin, Write, TotalFeesOperationClaims.Update };

    public class UpdateTotalFeeCommandHandler : IRequestHandler<UpdateTotalFeeCommand, UpdatedTotalFeeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITotalFeeRepository _totalFeeRepository;
        private readonly TotalFeeBusinessRules _totalFeeBusinessRules;

        public UpdateTotalFeeCommandHandler(IMapper mapper, ITotalFeeRepository totalFeeRepository,
                                         TotalFeeBusinessRules totalFeeBusinessRules)
        {
            _mapper = mapper;
            _totalFeeRepository = totalFeeRepository;
            _totalFeeBusinessRules = totalFeeBusinessRules;
        }

        public async Task<UpdatedTotalFeeResponse> Handle(UpdateTotalFeeCommand request, CancellationToken cancellationToken)
        {
            TotalFee? totalFee = await _totalFeeRepository.GetAsync(predicate: tf => tf.Id == request.Id, cancellationToken: cancellationToken);
            await _totalFeeBusinessRules.TotalFeeShouldExistWhenSelected(totalFee);
            totalFee = _mapper.Map(request, totalFee);

            await _totalFeeRepository.UpdateAsync(totalFee!);

            UpdatedTotalFeeResponse response = _mapper.Map<UpdatedTotalFeeResponse>(totalFee);
            return response;
        }
    }
}