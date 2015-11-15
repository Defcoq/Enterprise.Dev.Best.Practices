using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Model.Orders;
using EA.JP.Ecommerce.Services.ViewModels;
using AutoMapper;

namespace EA.JP.Ecommerce.Services.Mapping
{
    public static class OrderMapper
    {
        public static OrderView ConvertToOrderView(this Order order)
        {
            return Mapper.Map<Order, OrderView>(order);
        }

        public static IEnumerable<OrderSummaryView> ConvertToOrderSummaryViews(
                                                      this IEnumerable<Order> orders)
        {
            return Mapper.Map<IEnumerable<Order>, IEnumerable<OrderSummaryView>>(orders);
        }
    }

}
