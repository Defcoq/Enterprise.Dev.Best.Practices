using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Services.ViewModels;

namespace EA.JP.Ecommerce.Controllers.ViewModels.Checkout
{
    public class OrderConfirmationView
    {
        public BasketView Basket { get; set; }
        public IEnumerable<DeliveryAddressView> DeliveryAddresses { get; set; }
    }

}
