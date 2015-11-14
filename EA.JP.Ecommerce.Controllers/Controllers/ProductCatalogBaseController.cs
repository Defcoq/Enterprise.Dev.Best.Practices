using EA.JP.Ecommerce.Infrastructure.CookieStorage;
using EA.JP.Ecommerce.Services.Interfaces;
using EA.JP.Ecommerce.Services.Messaging.ProductCatalogService;
using EA.JP.Ecommerce.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EA.JP.Ecommerce.Controllers.Controllers
{
    public class ProductCatalogBaseController : BaseController
    {
        private readonly IProductCatalogService _productCatalogService;

        public ProductCatalogBaseController(
                          ICookieStorageService cookieStorageService,
                          IProductCatalogService productCatalogService)
            : base(cookieStorageService)
        {
            _productCatalogService = productCatalogService;
        }

        public IEnumerable<CategoryView> GetCategories()
        {
            GetAllCategoriesResponse response =
                                _productCatalogService.GetAllCategories();

            return response.Categories;
        }
    }
}
