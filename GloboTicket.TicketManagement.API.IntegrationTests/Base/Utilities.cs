using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TicketManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.API.IntegrationTests.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(GloboTicketDbContext context)
        {
            var concertGuid = Guid.Parse("C1D92B2D-5CD9-414B-BB4C-FA82F0DF3742");
            var playGuid = Guid.Parse("C92EA355-77EE-40A3-ACC7-D9FB4AD451DD");
            var conferenceGuid = Guid.Parse("64BFB2D8-9AC2-4BA0-94A2-48BA3B09E27B");

            context.Categories.Add(new Category
            {
                CategoryId = concertGuid,
                Name = "Concerts",
            });

            context.Categories.Add(new Category
            {
                CategoryId = playGuid,
                Name = "Plays",
            });

            context.Categories.Add(new Category
            {
                CategoryId = conferenceGuid,
                Name = "Conferences",
            });

            context.SaveChanges();
        }
    }
}
