using GloboTicket.TicketManagement.Application.Features.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.ViewModels
{
	public class EventDetailVm
	{
		public int EventId { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public string Artist { get; set; }
		public DateTime Date { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public Guid CategoryId { get; set; }
		public CategoryDto Category { get; set; }
	}
}
