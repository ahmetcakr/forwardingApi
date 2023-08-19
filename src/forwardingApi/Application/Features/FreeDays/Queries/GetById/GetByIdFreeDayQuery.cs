using Application.Features.FreeDays.Constants;
using Application.Features.FreeDays.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.FreeDays.Constants.FreeDaysOperationClaims;

namespace Application.Features.FreeDays.Queries.GetById;

public class GetByIdFreeDayQuery : IRequest<GetByIdFreeDayResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdFreeDayQueryHandler : IRequestHandler<GetByIdFreeDayQuery, GetByIdFreeDayResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFreeDayRepository _freeDayRepository;
        private readonly FreeDayBusinessRules _freeDayBusinessRules;

        public GetByIdFreeDayQueryHandler(IMapper mapper, IFreeDayRepository freeDayRepository, FreeDayBusinessRules freeDayBusinessRules)
        {
            _mapper = mapper;
            _freeDayRepository = freeDayRepository;
            _freeDayBusinessRules = freeDayBusinessRules;
        }

        public async Task<GetByIdFreeDayResponse> Handle(GetByIdFreeDayQuery request, CancellationToken cancellationToken)
        {
            FreeDay? freeDay = await _freeDayRepository.GetAsync(predicate: fd => fd.Id == request.Id, cancellationToken: cancellationToken);
            await _freeDayBusinessRules.FreeDayShouldExistWhenSelected(freeDay);

            GetByIdFreeDayResponse response = _mapper.Map<GetByIdFreeDayResponse>(freeDay);
            return response;
        }
    }
}