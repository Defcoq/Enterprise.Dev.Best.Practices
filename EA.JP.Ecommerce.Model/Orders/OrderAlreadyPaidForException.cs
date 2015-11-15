using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EA.JP.Ecommerce.Model.Orders
{
    public class OrderAlreadyPaidForException : Exception
    {
        public OrderAlreadyPaidForException(string message)
            : base(message)
        {
        }
    }

}
