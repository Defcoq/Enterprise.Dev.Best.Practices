using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EA.JP.Ecommerce.Model.Orders
{
    public class CannotAmendOrderException : Exception
    {
        public CannotAmendOrderException(string message)
            : base(message)
        {

        }
    }

}
