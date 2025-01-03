using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
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

namespace GloboTicket.TicketManagement.Application.UnitTests.Categories.Commands
{
    public class CreateCategoryTests
    {
        private readonly IMapper mapper;
        private readonly Mock<IAsyncRepository<Category>> mockCategoryRepository;

        public CreateCategoryTests()
        {
            mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            var handler = new CreateCategoryCommandHandler(mapper, mockCategoryRepository.Object);

            await handler.Handle(new CreateCategoryCommand()
            { Name = "Test", }, CancellationToken.None);

            var allCategories = await mockCategoryRepository.Object.ListAllAsync();
            allCategories.Count.ShouldBe(4);
        }
    }
}
