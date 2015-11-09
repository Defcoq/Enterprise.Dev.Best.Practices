﻿using Enterprise.Architec.DDD.AppService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Architec.DDD.AppService.Messages
{
  public  class FindBankAccountResponse : ResponseBase
    {
        public BankAccountView BankAccount { get; set; }
    }
}
