﻿using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent
{
	public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
	{
		private readonly IMapper mapper;
		private readonly IAsyncRepository<Event> eventRepository;

		public DeleteEventCommandHandler(
            IMapper mapper,
            IAsyncRepository<Event> eventRepository
            )
        {
			this.mapper = mapper;
			this.eventRepository = eventRepository;
		}

		public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
		{
			var eventToDelete = await eventRepository.GetByIdAsync(request.EventId);

			await eventRepository.DeleteAsync(eventToDelete);
		}
	}
}
