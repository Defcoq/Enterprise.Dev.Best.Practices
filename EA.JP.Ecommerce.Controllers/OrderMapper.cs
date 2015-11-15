using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Infrastructure.Payments;
using EA.JP.Ecommerce.Services.ViewModels;
using AutoMapper;

namespace EA.JP.Ecommerce.Controllers
{
    public static class OrderMapper
    {
        public static OrderPaymentRequest ConvertToOrderPaymentRequest(
                                                          this OrderView order)
        {
            return Mapper.Map<OrderView, OrderPaymentRequest>(order);
        }
    }

}
