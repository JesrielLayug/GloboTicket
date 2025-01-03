using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence.IntegrationTests
{
    public class GloboTicketDbContextTests
    {
        private readonly GloboTicketDbContext globoTicketDbContext;
        private readonly Mock<ILoggedInUserService> loggedInUserServiceMock;
        private readonly string loggedInUserId;

        public GloboTicketDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<GloboTicketDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            loggedInUserId = "00000000-0000-0000-0000-000000000000";
            loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            loggedInUserServiceMock.Setup(m => m.UserId).Returns(loggedInUserId);

            globoTicketDbContext = new GloboTicketDbContext(dbContextOptions, loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var ev = new Event() { EventId = Guid.NewGuid(), Name = "Test event" };

            globoTicketDbContext.Events.Add(ev);
            await globoTicketDbContext.SaveChangesAsync();

            ev.CreatedBy.ShouldBe(loggedInUserId);
        }
    }
}
