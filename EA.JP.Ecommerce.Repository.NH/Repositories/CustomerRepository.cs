using System.Collections.Generic;
using System.Linq;
using EA.JP.Ecommerce.Infrastructure.Querying;
using EA.JP.Ecommerce.Infrastructure.UnitOfWork;
using EA.JP.Ecommerce.Model.Customers;
using EA.JP.Ecommerce.Repository.NH.SessionStorage;
using NHibernate;
using NHibernate.Criterion;


namespace EA.JP.Ecommerce.Repository.NH.Repositories
{
    public class CustomerRepository : Repository<Customer, int>,
                                          ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork uow)
            : base(uow)
        {
        }

        public Customer FindBy(string identityToken)
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession()
                     .CreateCriteria(typeof(Customer))
                     .Add(Expression.Eq(PropertyNameHelper
                     .ResolvePropertyName<Customer>
                    (c => c.IdentityToken), identityToken));

            IList<Customer> customers = criteriaQuery.List<Customer>();

            Customer customer = customers.FirstOrDefault();
            return customer;
        }
    }

}
