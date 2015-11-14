using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Infrastructure.Domain;

namespace EA.JP.Ecommerce.Model.Basket
{
    public interface IBasketRepository : IRepository<Basket, Guid>
    {
    }

}
