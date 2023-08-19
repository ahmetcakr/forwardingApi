using Application.Features.FreeDays.Constants;
using Application.Features.FreeDays.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.FreeDays.Constants.FreeDaysOperationClaims;

namespace Application.Features.FreeDays.Commands.Create;

public class CreateFreeDayCommand : IRequest<CreatedFreeDayResponse>, ISecuredRequest, ITransactionalRequest
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? Day { get; set; }
    public int? Fee { get; set; }
    public int? Total { get; set; }
    public int? TotalFee { get; set; }

    public string[] Roles => new[] { Admin, Write, FreeDaysOperationClaims.Create };

    public class CreateFreeDayCommandHandler : IRequestHandler<CreateFreeDayCommand, CreatedFreeDayResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFreeDayRepository _freeDayRepository;
        private readonly FreeDayBusinessRules _freeDayBusinessRules;

        public CreateFreeDayCommandHandler(IMapper mapper, IFreeDayRepository freeDayRepository,
                                         FreeDayBusinessRules freeDayBusinessRules)
        {
            _mapper = mapper;
            _freeDayRepository = freeDayRepository;
            _freeDayBusinessRules = freeDayBusinessRules;
        }

        public async Task<CreatedFreeDayResponse> Handle(CreateFreeDayCommand request, CancellationToken cancellationToken)
        {
            FreeDay freeDay = _mapper.Map<FreeDay>(request);

            await _freeDayRepository.AddAsync(freeDay);

            CreatedFreeDayResponse response = _mapper.Map<CreatedFreeDayResponse>(freeDay);
            return response;
        }
    }
}