using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Infrastructure.UnitOfWork;
using EA.JP.Ecommerce.Model.Shipping;

namespace EA.JP.Ecommerce.Repository.NH.Repositories
{
    public class DeliveryOptionRepository : Repository<DeliveryOption, int>,
                                                           IDeliveryOptionRepository
    {
        public DeliveryOptionRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
