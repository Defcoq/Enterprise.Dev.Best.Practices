using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EA.SOA.EventTicket.DataContract
{
    [DataContract]
   public  class PurchaseTicketResponse
    {
        [DataMember]
        public string TicketId { get; set; }

        [DataMember]
        public String EventName { get; set; }

        [DataMember]
        public String EventId { get; set; }

        [DataMember]
        public int NoOfTickets { get; set; }

        [DataMember]
        public String Message { get; set; }

        public bool Success { get; set; }
    }
}
