using EA.JP.Ecommerce.Services.Messaging.ProductCatalogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.JP.Ecommerce.Services.Interfaces
{
    public interface IProductCatalogService
    {
        GetFeaturedProductsResponse GetFeaturedProducts();
        GetProductsByCategoryResponse GetProductsByCategory(
                                         GetProductsByCategoryRequest request);
        GetProductResponse GetProduct(GetProductRequest request);

        GetAllCategoriesResponse GetAllCategories();
    }

}
