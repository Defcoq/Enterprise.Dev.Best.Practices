using System;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace EA.JP.Ecommerce.Controllers.JsonDTOs
{
    public class JsonModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
                                ModelBindingContext bindingContext)
        {
            if (controllerContext == null)
                throw new ArgumentNullException("controllerContext");
            if (bindingContext == null)
                throw new ArgumentNullException("bindingContext");

            var serializer = new DataContractJsonSerializer(bindingContext.ModelType);
            var input = controllerContext.HttpContext.Request.InputStream;
            input.Position = 0;
            return serializer.ReadObject(input);
            //object request = bindingContext.ModelType;
            //return controllerContext.DeserializeJson<request>();

            //var serializer = new JavaScriptSerializer();
            //var form = controllerContext.RequestContext.HttpContext.Request.InputStream.ToString();
            //return serializer.Deserialize(HttpUtility.UrlDecode(form), bindingContext.ModelType);

        }
    }

    public class JsonBinder<T> : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return controllerContext.DeserializeJson<T>();
        }
    }

}
