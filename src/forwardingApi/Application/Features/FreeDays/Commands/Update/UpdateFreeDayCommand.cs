using Application.Features.FreeDays.Constants;
using Application.Features.FreeDays.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.FreeDays.Constants.FreeDaysOperationClaims;

namespace Application.Features.FreeDays.Commands.Update;

public class UpdateFreeDayCommand : IRequest<UpdatedFreeDayResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? Day { get; set; }
    public int? Fee { get; set; }
    public int? Total { get; set; }
    public int? TotalFee { get; set; }

    public string[] Roles => new[] { Admin, Write, FreeDaysOperationClaims.Update };

    public class UpdateFreeDayCommandHandler : IRequestHandler<UpdateFreeDayCommand, UpdatedFreeDayResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFreeDayRepository _freeDayRepository;
        private readonly FreeDayBusinessRules _freeDayBusinessRules;

        public UpdateFreeDayCommandHandler(IMapper mapper, IFreeDayRepository freeDayRepository,
                                         FreeDayBusinessRules freeDayBusinessRules)
        {
            _mapper = mapper;
            _freeDayRepository = freeDayRepository;
            _freeDayBusinessRules = freeDayBusinessRules;
        }

        public async Task<UpdatedFreeDayResponse> Handle(UpdateFreeDayCommand request, CancellationToken cancellationToken)
        {
            FreeDay? freeDay = await _freeDayRepository.GetAsync(predicate: fd => fd.Id == request.Id, cancellationToken: cancellationToken);
            await _freeDayBusinessRules.FreeDayShouldExistWhenSelected(freeDay);
            freeDay = _mapper.Map(request, freeDay);

            await _freeDayRepository.UpdateAsync(freeDay!);

            UpdatedFreeDayResponse response = _mapper.Map<UpdatedFreeDayResponse>(freeDay);
            return response;
        }
    }
}