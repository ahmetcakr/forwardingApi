using Application.Features.TotalFees.Constants;
using Application.Features.TotalFees.Constants;
using Application.Features.TotalFees.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.TotalFees.Constants.TotalFeesOperationClaims;

namespace Application.Features.TotalFees.Commands.Delete;

public class DeleteTotalFeeCommand : IRequest<DeletedTotalFeeResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, TotalFeesOperationClaims.Delete };

    public class DeleteTotalFeeCommandHandler : IRequestHandler<DeleteTotalFeeCommand, DeletedTotalFeeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITotalFeeRepository _totalFeeRepository;
        private readonly TotalFeeBusinessRules _totalFeeBusinessRules;

        public DeleteTotalFeeCommandHandler(IMapper mapper, ITotalFeeRepository totalFeeRepository,
                                         TotalFeeBusinessRules totalFeeBusinessRules)
        {
            _mapper = mapper;
            _totalFeeRepository = totalFeeRepository;
            _totalFeeBusinessRules = totalFeeBusinessRules;
        }

        public async Task<DeletedTotalFeeResponse> Handle(DeleteTotalFeeCommand request, CancellationToken cancellationToken)
        {
            TotalFee? totalFee = await _totalFeeRepository.GetAsync(predicate: tf => tf.Id == request.Id, cancellationToken: cancellationToken);
            await _totalFeeBusinessRules.TotalFeeShouldExistWhenSelected(totalFee);

            await _totalFeeRepository.DeleteAsync(totalFee!);

            DeletedTotalFeeResponse response = _mapper.Map<DeletedTotalFeeResponse>(totalFee);
            return response;
        }
    }
}