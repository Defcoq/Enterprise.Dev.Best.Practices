using Enterprise.Architec.DDD.AppService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Architec.DDD.AppService.Messages
{
   public  class FindAllBankAccountResponse : ResponseBase
    {
        public IList<BankAccountView> BankAccountView { get; set; }
    }
}
