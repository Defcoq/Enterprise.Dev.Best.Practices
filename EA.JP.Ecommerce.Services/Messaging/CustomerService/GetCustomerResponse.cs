using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Services.ViewModels;

namespace EA.JP.Ecommerce.Services.Messaging.CustomerService
{
    public class GetCustomerResponse
    {
        public bool CustomerFound { get; set; }
        public CustomerView Customer { get; set; }
        public IEnumerable<OrderSummaryView> Orders { get; set; }
    }

}
