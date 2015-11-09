using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Services.ViewModels;

namespace EA.JP.Ecommerce.Services.Messaging.ProductCatalogService
{
    public class GetAllCategoriesResponse
    {
        public IEnumerable<CategoryView> Categories { get; set; }
    }

}
