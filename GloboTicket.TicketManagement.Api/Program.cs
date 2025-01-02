namespace GloboTicket.TicketManagement.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder
                .ConfigureServices()
                .ConfigurePipeline();

            await app.ResetDatabaseAsync();
            app.Run();
        }
    }
}
