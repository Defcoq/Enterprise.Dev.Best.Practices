using EA.JP.Ecommerce.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.JP.Ecommerce.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        void RegisterAmended(IAggregateRoot entity,
                             IUnitOfWorkRepository unitofWorkRepository);
        void RegisterNew(IAggregateRoot entity,
                         IUnitOfWorkRepository unitofWorkRepository);
        void RegisterRemoved(IAggregateRoot entity,
                             IUnitOfWorkRepository unitofWorkRepository);
        void Commit();
    }
}
