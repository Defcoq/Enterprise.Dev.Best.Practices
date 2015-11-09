using EA.JP.Ecommerce.Infrastructure.Domain;
using EA.JP.Ecommerce.Infrastructure.UnitOfWork;
using EA.JP.Ecommerce.Repository.NH.SessionStorage;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.JP.Ecommerce.Repository.NH
{
    public class NHUnitOfWork : IUnitOfWork
    {
        public void RegisterAmended(IAggregateRoot entity,
                                    IUnitOfWorkRepository unitofWorkRepository)
        {
            SessionFactory.GetCurrentSession().SaveOrUpdate(entity);
        }

        public void RegisterNew(IAggregateRoot entity,
                                IUnitOfWorkRepository unitofWorkRepository)
        {
            SessionFactory.GetCurrentSession().Save(entity);
        }

        public void RegisterRemoved(IAggregateRoot entity,
                                    IUnitOfWorkRepository unitofWorkRepository)
        {
            SessionFactory.GetCurrentSession().Delete(entity);
        }

        public void Commit()
        {
            using (ITransaction transaction =
                           SessionFactory.GetCurrentSession().BeginTransaction())
            {
                try
                { transaction.Commit(); }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }

}
