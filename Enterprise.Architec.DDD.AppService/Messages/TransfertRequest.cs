using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Architec.DDD.AppService.Messages
{
   public class TransfertRequest
    {
        public Guid AccountIdTo { get; set; }
        public Guid AccountIdFrom { get; set; }
        public decimal Amount { get; set; }
    }
}
