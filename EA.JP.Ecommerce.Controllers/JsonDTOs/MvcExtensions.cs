using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace EA.JP.Ecommerce.Controllers.JsonDTOs
{
    public static class MvcExtensions
    {
        public static T DeserializeJson<T>(this ControllerContext context)
        {
            var serializer = new JavaScriptSerializer();
            var form = context.RequestContext.HttpContext.Request.Form.ToString();
            return serializer.Deserialize<T>(HttpUtility.UrlDecode(form));
        }
    }
}
