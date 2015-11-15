using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Services.ViewModels;
using EA.JP.Ecommerce.Controllers.ViewModels.CustomerAccount;

namespace EA.JP.Ecommerce.Controllers.ViewModels.CustomerAccount
{
    public class CustomersOrderSummaryView : BaseCustomerAccountView
    {
        public IEnumerable<OrderSummaryView> Orders { get; set; }
    }

}
