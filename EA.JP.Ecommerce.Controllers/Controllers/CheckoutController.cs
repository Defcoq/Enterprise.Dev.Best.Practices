using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using EA.JP.Ecommerce.Controllers.ViewModels.Checkout;
using EA.JP.Ecommerce.Infrastructure.Authentication;
using EA.JP.Ecommerce.Infrastructure.CookieStorage;
using EA.JP.Ecommerce.Services.Interfaces;
using EA.JP.Ecommerce.Services.Messaging.CustomerService;
using EA.JP.Ecommerce.Services.Messaging.OrderService;
using EA.JP.Ecommerce.Services.Messaging.ProductCatalogService;
using EA.JP.Ecommerce.Services.ViewModels;

namespace EA.JP.Ecommerce.Controllers.Controllers
{
    public class CheckoutController : BaseController
    {
        private readonly ICookieStorageService _cookieStorageService;
        private readonly IBasketService _basketService;
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly IFormsAuthentication _formsAuthentication;

        public CheckoutController(ICookieStorageService cookieStorageService,
                                  IBasketService basketService,
                                  ICustomerService customerService,
                                  IOrderService orderService,
                                  IFormsAuthentication formsAuthentication)
            : base(cookieStorageService)
        {
            _cookieStorageService = cookieStorageService;
            _basketService = basketService;
            _customerService = customerService;
            _orderService = orderService;
            _formsAuthentication = formsAuthentication;
        }

        [Authorize]
        public ActionResult Checkout()
        {
            GetCustomerRequest customerRequest = new GetCustomerRequest()
            {
                CustomerIdentityToken = _formsAuthentication.GetAuthenticationToken()
            };

            GetCustomerResponse customerResponse =
                            _customerService.GetCustomer(customerRequest);
            CustomerView customerView = customerResponse.Customer;


            if (customerView.DeliveryAddressBook.Count() > 0)
            {
                OrderConfirmationView orderConfirmationView =
                                         new OrderConfirmationView();
                GetBasketRequest getBasketRequest = new GetBasketRequest()
                {
                    BasketId = base.GetBasketId()
                };

                GetBasketResponse basketResponse =
                                       _basketService.GetBasket(getBasketRequest);

                orderConfirmationView.Basket = basketResponse.Basket;
                orderConfirmationView.DeliveryAddresses =
                                       customerView.DeliveryAddressBook;

                return View("ConfirmOrder", orderConfirmationView);
            }

            return AddDeliveryAddress();
        }

        [Authorize]
        public ActionResult AddDeliveryAddress()
        {
            DeliveryAddressView deliveryAddressView = new DeliveryAddressView();
            return View("AddDeliveryAddress", deliveryAddressView);
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddDeliveryAddress(DeliveryAddressView deliveryAddressView)
        {
            DeliveryAddressAddRequest request = new DeliveryAddressAddRequest();
            request.Address = deliveryAddressView;
            request.CustomerIdentityToken = _formsAuthentication.GetAuthenticationToken();

            _customerService.AddDeliveryAddress(request);

            return Checkout();
        }

        [Authorize]
        public ActionResult PlaceOrder(FormCollection collection)
        {
            CreateOrderRequest request = new CreateOrderRequest();
            request.BasketId = base.GetBasketId();
            request.CustomerIdentityToken = _formsAuthentication.GetAuthenticationToken();
            request.DeliveryId =
                   int.Parse(collection[FormDataKeys.DeliveryAddress.ToString()]);

            CreateOrderResponse response = _orderService.CreateOrder(request);


            _cookieStorageService.Save(CookieDataKeys.BasketItems.ToString(),
                                       "0", DateTime.Now.AddDays(1));
            _cookieStorageService.Save(CookieDataKeys.BasketTotal.ToString(),
                                       "0", DateTime.Now.AddDays(1));

            return RedirectToAction("CreatePaymentFor", "Payment",
                                    new { orderId = response.Order.Id });
        }
    }

}
