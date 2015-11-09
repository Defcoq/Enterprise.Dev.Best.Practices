using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Services.ViewModels;

namespace EA.JP.Ecommerce.Controllers.ViewModels.ProductCatalog
{
    public class ProductDetailView : BaseProductCatalogPageView
    {
        public ProductView Product { get; set; }
    }

}
