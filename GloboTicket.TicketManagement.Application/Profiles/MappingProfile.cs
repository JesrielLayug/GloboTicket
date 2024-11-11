using AutoMapper;
using GloboTicket.TicketManagement.Application.Features.Dtos;
using GloboTicket.TicketManagement.Application.Features.ViewModels;
using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Profiles
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Event, EventListVm>().ReverseMap();
			CreateMap<Event, EventDetailVm>().ReverseMap();
			CreateMap<Category, CategoryDto>().ReverseMap();
		}
	}
}
