using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Application.Features.Queries;
using GloboTicket.TicketManagement.Application.Features.ViewModels;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.QueryHandlers
{
	public class GetEventsListQueryHandler : IRequestHandler<GetEventListQuery, List<EventListVm>>
	{
		private readonly IMapper mapper;
		private readonly IAsyncRepository<Event> eventRepository;

		public GetEventsListQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
		{
			this.mapper = mapper;
			this.eventRepository = eventRepository;
		}

		public async Task<List<EventListVm>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
		{
			var allEvents = (await eventRepository.ListAllAsync()).OrderBy(x => x.Date);
			return mapper.Map<List<EventListVm>>(allEvents);
		}
	}
}
