using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Architec.DDD.AppService.Messages
{
   public  class BankAccountCreateResponse : ResponseBase
    {
        public Guid BankAccountId { get; set; }
    }
}
