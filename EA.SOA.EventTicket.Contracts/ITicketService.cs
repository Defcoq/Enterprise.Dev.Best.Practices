using EA.SOA.EventTicket.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EA.SOA.EventTicket.Contracts
{
    [ServiceContract(Namespace = "http://EA.SOA.EventTickets/")]
    public interface ITicketService
    {
        [OperationContract()]
        ReserveTicketResponse ReserveTicket(ReserveTicketRequest reserveTicketRequest);

        [OperationContract()]
        PurchaseTicketResponse PurchaseTicket(PurchaseTicketRequest purchaseTicketRequest);
    }
}
