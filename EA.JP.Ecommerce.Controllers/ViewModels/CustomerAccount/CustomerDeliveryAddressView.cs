using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Services.ViewModels;

namespace EA.JP.Ecommerce.Controllers.ViewModels.CustomerAccount
{
    public class CustomerDeliveryAddressView : BaseCustomerAccountView
    {
        public CustomerView CustomerView { get; set; }
        public DeliveryAddressView Address { get; set; }
    }

}
