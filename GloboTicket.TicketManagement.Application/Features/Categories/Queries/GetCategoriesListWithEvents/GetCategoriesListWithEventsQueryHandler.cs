using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
	public class GetCategoriesListWithEventsQueryHandler : 
		IRequestHandler<GetCategoriesListWithEventsQuery, List<CategoryEventListVm>>
	{
		private readonly IMapper mapper;
		private readonly ICategoryRepository categoryRepository;

		public GetCategoriesListWithEventsQueryHandler(
            IMapper mapper,
            ICategoryRepository categoryRepository
            )
        {
			this.mapper = mapper;
			this.categoryRepository = categoryRepository;
		}

		public async Task<List<CategoryEventListVm>> Handle(GetCategoriesListWithEventsQuery request, CancellationToken cancellationToken)
		{
			var list = await categoryRepository.GetCategoriesWithEvents(
				request.IncludeHistory
				);

			return mapper.Map<List<CategoryEventListVm>>( list );
		}
	}
}
