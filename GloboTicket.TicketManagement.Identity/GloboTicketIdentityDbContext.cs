using GloboTicket.TicketManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Identity
{
    public class GloboTicketIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public GloboTicketIdentityDbContext()
        {
            
        }

        public GloboTicketIdentityDbContext(
            DbContextOptions<GloboTicketIdentityDbContext> options
            ) : base( options ) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
            .LogTo(Console.WriteLine)
            .EnableSensitiveDataLogging();
    }
}
