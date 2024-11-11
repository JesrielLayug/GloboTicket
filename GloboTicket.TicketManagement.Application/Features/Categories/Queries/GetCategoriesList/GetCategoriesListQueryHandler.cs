using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList
{
	public class GetCategoriesListQueryHandler :
		IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
	{
		private readonly IMapper mapper;
		private readonly IAsyncRepository<Category> categoryRepository;

		public GetCategoriesListQueryHandler(
            IMapper mapper,
            IAsyncRepository<Category> categoryRepository
            )
        {
			this.mapper = mapper;
			this.categoryRepository = categoryRepository;
		}

		public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, 
			CancellationToken cancellationToken)
		{
			var allCategories = (await categoryRepository.ListAllAsync())
				.OrderBy(x => x.Name);

			return mapper.Map<List<CategoryListVm>>(allCategories);
		}
	}
}
