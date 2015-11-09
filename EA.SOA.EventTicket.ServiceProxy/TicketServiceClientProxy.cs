using EA.SOA.EventTicket.Contracts;
using EA.SOA.EventTicket.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EA.SOA.EventTicket.ServiceProxy
{
    public class TicketServiceClientProxy : ClientBase<ITicketService>, ITicketService
    {
        public ReserveTicketResponse ReserveTicket(ReserveTicketRequest reserveTicketRequest)
        {
            return base.Channel.ReserveTicket(reserveTicketRequest);
        }

        public PurchaseTicketResponse PurchaseTicket(PurchaseTicketRequest purchaseTicketRequest)
        {
            return base.Channel.PurchaseTicket(purchaseTicketRequest);
        }
    }
}
