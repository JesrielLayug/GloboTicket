using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using GloboTicket.TicketManagement.Application.Profiles;
using GloboTicket.TicketManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.UnitTests.Categories.Queries
{
    public class GetCategoriesListWithEventsQueryHandlerTests
    {
        private readonly IMapper mapper;
        private readonly Mock<ICategoryRepository> mockCategoryRepository;

        public GetCategoriesListWithEventsQueryHandlerTests()
        {
            mockCategoryRepository = RepositoryMocks.GetCategoriesWithEventsRepository();
            var configurationProvider = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCategoriesListWithEventsTest()
        {
            var handler = new GetCategoriesListWithEventsQueryHandler(mapper, mockCategoryRepository.Object);

            var result = await handler.Handle(new GetCategoriesListWithEventsQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CategoryEventListVm>>();

            result.Count.ShouldBe(3);
        }
    }
}
