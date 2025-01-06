using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Application.Models.Mail;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly IEmailService emailService;
		private readonly ILogger<CreateEventCommandHandler> Logger;

        public CreateEventCommandHandler(
            IMapper mapper,
            IEventRepository eventRepository,
			IEmailService emailService,
			ILogger<CreateEventCommandHandler> logger
            )
        {
			this.mapper = mapper;
			this.eventRepository = eventRepository;
            this.emailService = emailService;
			this.Logger = logger;
        }

		public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
		{
			var @event = mapper.Map<Event>( request );

			var validator = new CreateEventCommandValidator(eventRepository);
			var validationResult = await validator.ValidateAsync(request);

			if(validationResult.Errors.Count > 0)
			{
				throw new Exceptions.ValidationException(validationResult);
			}

			@event = await eventRepository.AddAsync( @event );

			// Sending email notification to admin address
			//var email = new Email()
			//{
			//	To = "layugjesriel39@gmail.com",
			//	Body = $"A new event was created: {request}",
			//	Subject = "Event created."
			//};

			try
			{
				//await emailService.SendEmail(email);
			}
			catch (Exception ex)
			{
				Logger.LogError($"Mailing about event {@event.EventId} failed due to an error with the mail service: {ex.Message}");
				// this shouldn't stop the API from doing else so this can be logged
			}

			return @event.EventId;
		}
	}
}
