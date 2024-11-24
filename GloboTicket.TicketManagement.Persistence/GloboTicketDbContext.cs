using GloboTicket.TicketManagement.Domain.Common;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence
{
    public class GloboTicketDbContext : DbContext
    {
        public GloboTicketDbContext(DbContextOptions<GloboTicketDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GloboTicketDbContext).Assembly);

            // seed data, send through migrations
            var concertGuid = Guid.Parse("C0D92B2D-5CD9-414B-BB4C-FA82F0DF3742");
            var musicalGuid = Guid.Parse("727EF49E-392C-4DC4-9465-90F292C83C3B");
            var playGuid = Guid.Parse("C91EA355-77EE-40A3-ACC7-D9FB4AD451DD");
            var conferenceGuid = Guid.Parse("64AFB2D8-9AC2-4BA0-94A2-48BA3B09E27B");

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = concertGuid,
                Name = "Concerts"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = playGuid,
                Name = "Plays"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = conferenceGuid,
                Name = "Conferences"
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
