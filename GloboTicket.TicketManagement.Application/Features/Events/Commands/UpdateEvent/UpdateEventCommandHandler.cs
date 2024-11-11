using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent
{
	public class UpdateEventCommandHandler :
		IRequestHandler<UpdateEventCommand>
	{
		private readonly IMapper mapper;
		private readonly IAsyncRepository<Event> eventRepository;

		public UpdateEventCommandHandler(
			IMapper mapper,
			IAsyncRepository<Event> eventRepository
			)
        {
			this.mapper = mapper;
			this.eventRepository = eventRepository;
		}

        public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
		{
			var eventToUpdate = await eventRepository.GetByIdAsync(request.EventId);

			mapper.Map(request, eventToUpdate, typeof(UpdateEventCommandHandler), typeof(Event));

			await eventRepository.UpdateAsync(eventToUpdate);
		}
	}
}
