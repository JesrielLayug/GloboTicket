﻿using GloboTicket.TicketManagement.Application;
using GloboTicket.TicketManagement.Infrastructure;
using GloboTicket.TicketManagement.Persistence;

namespace GloboTicket.TicketManagement.Api
{
    public static class Startup
    {
        public static WebApplication ConfigureServices(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);

            builder.Services.AddControllers();

            builder.Services.AddCors(
                options => options.AddPolicy(
                    "open",
                    policy => policy.WithOrigins([builder.Configuration["ApiUrl"] ??
                    "https://localhost:7020",
                        builder.Configuration["BlazorUrl"] ??
                    "https://localhost:7080"])

                    .AllowAnyMethod()
                    .SetIsOriginAllowed(pol => true)
                    .AllowAnyHeader()
                    .AllowCredentials()
                ));

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {

        }
    }
}
