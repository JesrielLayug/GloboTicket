using GloboTicket.TicketManagement.Application.Contracts;
using System.Security.Claims;

namespace GloboTicket.TicketManagement.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string UserId
        {
            get
            {
                return httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }
    }
}
