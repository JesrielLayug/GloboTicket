using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        private readonly GloboTicketDbContext dbContext;

        public EventRepository(GloboTicketDbContext dbContext) : base (dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            var matches = dbContext.Events.Any(e => e.Name.Equals(name) &&
            e.Date.Date.Equals(eventDate.Date));

            return Task.FromResult(matches);
        }
    }
}
