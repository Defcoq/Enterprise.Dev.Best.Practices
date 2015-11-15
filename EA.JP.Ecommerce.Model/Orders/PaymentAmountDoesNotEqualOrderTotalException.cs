using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EA.JP.Ecommerce.Model.Orders
{
    public class PaymentAmountDoesNotEqualOrderTotalException : Exception
    {
        public PaymentAmountDoesNotEqualOrderTotalException(string message)
            : base(message)
        {
        }
    }

}
