﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Services.ViewModels;

namespace EA.JP.Ecommerce.Controllers.ViewModels.CustomerAccount
{
    public class CustomerDetailView : BaseCustomerAccountView
    {
        public CustomerView Customer { get; set; }
    }

}
