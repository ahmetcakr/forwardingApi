using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetList;
public class GetListBookingQuery : IRequest<GetListResponse<GetListBookingListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListBookingQueryHandler : IRequestHandler<GetListBookingQuery, GetListResponse<GetListBookingListItemDto>>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public GetListBookingQueryHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBookingListItemDto>> Handle(GetListBookingQuery request, CancellationToken cancellationToken)
        {
            Paginate<Booking> models = (Paginate<Booking>)await _bookingRepository.GetListAsync(
                include: 
                m => 
                m.Include(m => m.ApplyTo)
                .Include(m => m.Company)
                .Include(m => m.Pol)
                .Include(m => m.Pod)
                .Include(m => m.Route)
                .Include(m => m.Consigne)
                .Include(m => m.Company)
                .Include(m => m.Demurrage)
                .Include(m => m.Detention)
                .Include(m => m.Feeder)
                .Include(m => m.FeederVoyage)
                .Include(m => m.FreeDay)
                .Include(m => m.MarketingResponsible)
                .Include(m => m.OperationResponsible)
                .Include(m => m.Ship)
                .Include(m => m.Shipper)
                .Include(m => m.ShipVoyage)
                .Include(m => m.TotalFee)
                .Include(m => m.Notify),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
                );

            var response = _mapper.Map<GetListResponse<GetListBookingListItemDto>>(models);
            return response;
        }
    }
}
