using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Profiles;
using GloboTicket.TicketManagement.Application.UnitTests.Mocks;
using GloboTicket.TicketManagement.Domain.Entities;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.UnitTests.Categories.Queries
{
    public class GetCategoriesListQueryHandlerTests
    {
        private readonly IMapper mapper;
        private readonly Mock<IAsyncRepository<Category>> mockCategoryRepository;

        public GetCategoriesListQueryHandlerTests()
        {
            mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCategoriesListTest()
        {
            var handler = new GetCategoriesListQueryHandler(mapper, mockCategoryRepository.Object);

            var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CategoryListVm>>();

            result.Count.ShouldBe(3);
        }
    }
}
