using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
	public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
	{
		private readonly IMapper mapper;
		private readonly IEventRepository eventRepository;

		public CreateEventCommandHandler(
            IMapper mapper,
            IEventRepository eventRepository
            )
        {
			this.mapper = mapper;
			this.eventRepository = eventRepository;
		}

		public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
		{
			var @event = mapper.Map<Event>( request );

			var validator = new CreateEventCommandValidator();
			var validationResult = await validator.ValidateAsync(request);

			@event = await eventRepository.AddAsync( @event );

			return @event.EventId;
		}
	}
}
