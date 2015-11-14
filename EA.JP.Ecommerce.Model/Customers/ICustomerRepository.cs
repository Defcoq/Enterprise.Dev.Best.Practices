using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Infrastructure.Domain;

namespace EA.JP.Ecommerce.Model.Customers
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
        Customer FindBy(string identityToken);
    }

}
