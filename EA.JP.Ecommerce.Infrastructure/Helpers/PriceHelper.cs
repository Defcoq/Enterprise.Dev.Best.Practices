using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EA.JP.Ecommerce.Infrastructure.Helpers
{
    public static class PriceHelper
    {
        public static string FormatMoney(this decimal price)
        {
            return String.Format("${0}", price);
        }
    }

}
