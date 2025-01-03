using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IAsyncRepository<Category>> GetCategoryRepository()
        {
            var concertGuid = Guid.Parse("C0D92B2D-5CD9-414B-BB4C-FA82F0DF3742");
            var musicalGuid = Guid.Parse("727EF49E-392C-4DC4-9465-90F292C83C3B");
            var playGuid = Guid.Parse("C91EA355-77EE-40A3-ACC7-D9FB4AD451DD");
            var conferenceGuid = Guid.Parse("64AFB2D8-9AC2-4BA0-94A2-48BA3B09E27B");

            var categories = new List<Category>
            {
                new Category
                {
                    CategoryId = concertGuid,
                    Name = "Concerts"
                },
                new Category
                {
                    CategoryId = playGuid,
                    Name = "Plays"
                },
                new Category
                {
                    CategoryId = conferenceGuid,
                    Name = "Conferences"
                }

            };

            var mockCategoryRepository = new Mock<IAsyncRepository<Category>>();
            mockCategoryRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(categories);

            mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync(
                (Category category) =>
                {
                    categories.Add(category);
                    return category;
                });

            return mockCategoryRepository;
        }

        public static Mock<ICategoryRepository> GetCategoriesWithEventsRepository()
        {
            var concertGuid = Guid.Parse("C0D92B2D-5CD9-414B-BB4C-FA82F0DF3742");
            var playGuid = Guid.Parse("C91EA355-77EE-40A3-ACC7-D9FB4AD451DD");
            var conferenceGuid = Guid.Parse("64AFB2D8-9AC2-4BA0-94A2-48BA3B09E27B");

            var categories = new List<Category>
            {
                new Category
                {
                    CategoryId = Guid.NewGuid(),
                    Name = "Concerts",
                    Events = new List<Event>
                    {
                        new Event { EventId = Guid.NewGuid(), Name = "Rock Concert", Date = DateTime.UtcNow }
                    }
                },
                new Category
                {
                    CategoryId = Guid.NewGuid(),
                    Name = "Plays",
                    Events = new List<Event>
                    {
                        new Event { EventId = Guid.NewGuid(), Name = "Drama Play", Date = DateTime.UtcNow }
                    }
                },
                new Category
                {
                    CategoryId = Guid.NewGuid(),
                    Name = "Conferences",
                    Events = new List<Event>
                    {
                        new Event { EventId = Guid.NewGuid(), Name = "Tech Conference", Date = DateTime.UtcNow }
                    }
                }
            };

            var mockRepo = new Mock<ICategoryRepository>();
            mockRepo.Setup(repo => repo.GetCategoriesWithEvents(It.IsAny<bool>()))
                    .ReturnsAsync(categories);

            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync(
                (Category category) =>
                {
                    categories.Add(category);
                    return category;
                });

            return mockRepo;
        }

    }
}
