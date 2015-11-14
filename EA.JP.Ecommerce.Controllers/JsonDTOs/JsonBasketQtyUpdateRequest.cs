using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web.Mvc;

namespace EA.JP.Ecommerce.Controllers.JsonDTOs
{
    [DataContract]
    [ModelBinder(typeof(JsonModelBinder))]
    public class JsonBasketQtyUpdateRequest
    {
        [DataMember]
        public JsonBasketItemUpdateRequest[] Items { get; set; }
    }

}
