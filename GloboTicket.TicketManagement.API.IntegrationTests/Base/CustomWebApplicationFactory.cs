using GloboTicket.TicketManagement.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.API.IntegrationTests.Base
{
    public class CustomWebApplicationFactory<TProgram>
        : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services
                    .AddEntityFrameworkInMemoryDatabase()
                    .AddDbContext<GloboTicketDbContext>((sp, options) =>
                    {
                        options.UseInMemoryDatabase("GloboTicketDbContextInMemoryTest").UseInternalServiceProvider(sp);
                    });


                //services.AddDbContext<GloboTicketDbContext>(options =>
                //{
                //    options.UseInMemoryDatabase("GloboTicketDbContextInMemoryTest");
                //});

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<GloboTicketDbContext>();

                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TProgram>>>();

                    context.Database.EnsureCreated();

                    try
                    {
                        Utilities.InitializeDbForTests(context);
                    }
                    catch(Exception ex)
                    {
                        logger.LogError(ex, $"An error occured seeding the database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }

        public HttpClient GetAnonymousClient()
        {
            return this.CreateClient();
        }
    }
}
