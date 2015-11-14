using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EA.JP.Ecommerce.Controllers.ActionArguments
{
    public class HttpRequestActionArguments : IActionArguments
    {
        public string GetValueForArgument(ActionArgumentKey key)
        {
            return HttpContext.Current.Request.QueryString[key.ToString()];
        }
    }

}
