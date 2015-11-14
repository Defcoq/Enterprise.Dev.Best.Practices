﻿using EA.JP.Ecommerce.Infrastructure.Logging;
using EA.JP.Ecommerce.Infrastructure.UnitOfWork;
using EA.JP.Ecommerce.Infrastructure.Configuration;
using EA.JP.Ecommerce.Model.Categories;
using EA.JP.Ecommerce.Model.Products;
using EA.JP.Ecommerce.Services.Implementations;
using EA.JP.Ecommerce.Services.Interfaces;
using StructureMap;
using StructureMap.Configuration.DSL;
using EA.JP.Ecommerce.Infrastructure.Email;
using EA.JP.Ecommerce.Model.Basket;
using EA.JP.Ecommerce.Model.Shipping;
using EA.JP.Ecommerce.Infrastructure.CookieStorage;
using EA.JP.Ecommerce.Model.Customers;
using EA.JP.Ecommerce.Infrastructure.Authentication;
using EA.JP.Ecommerce.Controllers.ActionArguments;

namespace EA.JP.Ecommerce.WEB.MVC.UI
{
    public class BootStrapper
    {
        public static void ConfigureDependencies()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<ControllerRegistry>();

            });
        }

        public class ControllerRegistry : Registry
        {
            public ControllerRegistry()
            {
                // Repositories
                For<ICustomerRepository>().Use<Repository.NH.Repositories.CustomerRepository>();
                For<IBasketRepository>().Use<Repository.NH.Repositories.BasketRepository>();
                For<IDeliveryOptionRepository>().Use<Repository.NH.Repositories.DeliveryOptionRepository>();

                For<ICategoryRepository>().Use<Repository.NH.Repositories.CategoryRepository>();
                For<IProductTitleRepository>().Use<Repository.NH.Repositories.ProductTitleRepository>();
                For<IProductRepository>().Use<Repository.NH.Repositories.ProductRepository>();
                For<IUnitOfWork>().Use<Repository.NH.NHUnitOfWork>();

                // Product Catalogue                                         
                For<IProductCatalogService>().Use<ProductCatalogService>();
                For<IBasketService>().Use<BasketService>();
                For<ICookieStorageService>().Use<CookieStorageService> ();

                // Application Settings                 
                For<IApplicationSettings>().Use<WebConfigApplicationSettings>();

                // Logger
                For<ILogger>().Use<Log4NetAdapter>();

                // Email Service                 
                For<IEmailService>().Use<TextLoggingEmailService>();

                For<ICustomerService>().Use<CustomerService>();

                // Authentication
                For<IExternalAuthenticationService>().Use<JanrainAuthenticationService>();
                For<IFormsAuthentication>().Use<AspFormsAuthentication>();
                For<ILocalAuthenticationService>().Use<AspMembershipAuthentication>();

                // Controller Helpers
                For<IActionArguments>().Use<HttpRequestActionArguments>();
            }
        }
    }
}
