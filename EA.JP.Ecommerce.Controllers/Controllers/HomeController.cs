using EA.JP.Ecommerce.Controllers.ViewModels.ProductCatalog;
using EA.JP.Ecommerce.Services.Interfaces;
using EA.JP.Ecommerce.Services.Messaging.ProductCatalogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EA.JP.Ecommerce.Controllers.Controllers
{
    public class HomeController : ProductCatalogBaseController
    {
        private readonly IProductCatalogService _productCatalogService;

        public HomeController(IProductCatalogService productCatalogService)
            : base(productCatalogService)
        {
            _productCatalogService = productCatalogService;
        }

        public ActionResult Index()
        {
            HomePageView homePageView = new HomePageView();
            homePageView.Categories = base.GetCategories();

            GetFeaturedProductsResponse response =
                           _productCatalogService.GetFeaturedProducts();
            homePageView.Products = response.Products;

            return View(homePageView);
        }
    }
}
