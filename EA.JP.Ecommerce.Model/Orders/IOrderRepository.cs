using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Infrastructure.Domain;

namespace EA.JP.Ecommerce.Model.Orders
{
    public interface IOrderRepository : IRepository<Order, int>
    {
    }
}
