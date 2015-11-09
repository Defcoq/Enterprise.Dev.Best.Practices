using System.Collections.Generic;
using EA.JP.Ecommerce.Services.ViewModels;

namespace EA.JP.Ecommerce.Controllers.ViewModels.ProductCatalog
{
    public class HomePageView : BaseProductCatalogPageView
    {
        public IEnumerable<ProductSummaryView> Products { get; set; }
    }

}
