namespace GloboTicket.TicketManagement.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder
                .ConfigureServices()
                .ConfigurePipeline();

            app.Run();
        }
    }
}
