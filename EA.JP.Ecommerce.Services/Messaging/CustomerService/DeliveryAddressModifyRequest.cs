﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Services.ViewModels;

namespace EA.JP.Ecommerce.Services.Messaging.CustomerService
{
    public class DeliveryAddressModifyRequest
    {
        public string CustomerIdentityToken { get; set; }
        public DeliveryAddressView Address { get; set; }
    }

}
