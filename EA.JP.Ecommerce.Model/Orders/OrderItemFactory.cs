using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Model.Products;

namespace EA.JP.Ecommerce.Model.Orders
{
    public static class OrderItemFactory
    {
        public static OrderItem CreateItemFor(Product product, Order order, int qty)
        {
            return new OrderItem(product, order, qty);
        }
    }

}
