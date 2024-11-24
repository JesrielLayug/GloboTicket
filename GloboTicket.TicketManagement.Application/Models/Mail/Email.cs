using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Models.Mail
{
    /*
     *  Why did we not put this model on the Domain folder?
     *  
     *  - This is because Email class has nothing to do with domain that GloboTicket works with.
     *  - It just a class and a type, and we need to define under application project for the email service to work correctly.
    */

    public class Email
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
