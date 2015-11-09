using System.Collections.Generic;
using EA.JP.Ecommerce.Services.ViewModels;

namespace EA.JP.Ecommerce.Controllers.ViewModels.ProductCatalog
{
    public abstract class BaseProductCatalogPageView
    {
        public IEnumerable<CategoryView> Categories { get; set; }
    }

}
