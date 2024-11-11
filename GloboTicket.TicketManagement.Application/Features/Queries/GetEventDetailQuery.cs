using GloboTicket.TicketManagement.Application.Features.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Queries
{
	public class GetEventDetailQuery : IRequest<EventDetailVm>
	{
		public Guid Id { get; set; }
	}
}
