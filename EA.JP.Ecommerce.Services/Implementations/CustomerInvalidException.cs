using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EA.JP.Ecommerce.Services.Implementations
{
    public class CustomerInvalidException : Exception
    {
        public CustomerInvalidException(string message)
            : base(message)
        {
        }
    }

}
