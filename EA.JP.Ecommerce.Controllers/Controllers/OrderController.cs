using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using EA.JP.Ecommerce.Controllers.ViewModels.CustomerAccount;
using EA.JP.Ecommerce.Infrastructure.Authentication;
using EA.JP.Ecommerce.Infrastructure.CookieStorage;
using EA.JP.Ecommerce.Services.Interfaces;
using EA.JP.Ecommerce.Services.Messaging.CustomerService;
using EA.JP.Ecommerce.Services.Messaging.OrderService;

namespace EA.JP.Ecommerce.Controllers.Controllers
{
    public class OrderController : BaseController
    {
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly IFormsAuthentication _formsAuthentication;

        public OrderController(ICustomerService customerService,
                               IOrderService orderService,
                               IFormsAuthentication formsAuthentication,
                               ICookieStorageService cookieStorageService)
            : base(cookieStorageService)
        {
            _customerService = customerService;
            _orderService = orderService;
            _formsAuthentication = formsAuthentication;
        }

        [Authorize]
        public ActionResult List()
        {
            GetCustomerRequest request = new GetCustomerRequest()
            {
                CustomerIdentityToken = _formsAuthentication.GetAuthenticationToken(),
                LoadOrderSummary = true
            };

            GetCustomerResponse response = _customerService.GetCustomer(request);

            CustomersOrderSummaryView customersOrderSummaryView =
                                                new CustomersOrderSummaryView();
            customersOrderSummaryView.Orders = response.Orders;
            customersOrderSummaryView.BasketSummary = base.GetBasketSummaryView();

            return View(customersOrderSummaryView);
        }

        [Authorize]
        public ActionResult Detail(int orderId)
        {
            GetOrderRequest request = new GetOrderRequest() { OrderId = orderId };
            GetOrderResponse response = _orderService.GetOrder(request);

            CustomerOrderView orderView = new CustomerOrderView();
            orderView.BasketSummary = base.GetBasketSummaryView();
            orderView.Order = response.Order;

            return View(orderView);
        }
    }

}
