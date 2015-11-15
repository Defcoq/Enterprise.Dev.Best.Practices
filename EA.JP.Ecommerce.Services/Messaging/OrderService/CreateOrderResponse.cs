using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Services.ViewModels;

namespace EA.JP.Ecommerce.Services.Messaging.OrderService
{
    public class CreateOrderResponse
    {
        public OrderView Order { get; set; }
    }

}
