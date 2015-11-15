using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Infrastructure.UnitOfWork;
using EA.JP.Ecommerce.Model.Orders;

namespace EA.JP.Ecommerce.Repository.NH.Repositories
{
    public class OrderRepository : Repository<Order, int>, IOrderRepository
    {
        public OrderRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
