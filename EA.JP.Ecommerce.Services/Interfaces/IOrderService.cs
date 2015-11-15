using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Services.Messaging.OrderService;

namespace EA.JP.Ecommerce.Services.Interfaces
{
    public interface IOrderService
    {
        CreateOrderResponse CreateOrder(CreateOrderRequest request);

        SetOrderPaymentResponse SetOrderPayment(SetOrderPaymentRequest paymentRequest);

        GetOrderResponse GetOrder(GetOrderRequest request);
    }

}
