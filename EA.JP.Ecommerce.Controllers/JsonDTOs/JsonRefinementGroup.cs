using System.Runtime.Serialization;
using System.Web.Mvc;

namespace EA.JP.Ecommerce.Controllers.JsonDTOs
{
    [DataContract]
    [ModelBinder(typeof(JsonModelBinder))]
    public class JsonRefinementGroup
    {
        [DataMember]
        public int GroupId { get; set; }

        [DataMember]
        public int[] SelectedRefinements { get; set; }
    }

}
