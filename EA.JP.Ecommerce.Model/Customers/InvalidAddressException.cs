using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EA.JP.Ecommerce.Model.Customers
{
    public class InvalidAddressException : Exception
    {
        public InvalidAddressException(string message)
            : base(message)
        {
        }
    }
}
