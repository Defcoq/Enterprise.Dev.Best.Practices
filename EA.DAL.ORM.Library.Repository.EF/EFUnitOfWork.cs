using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.DAL.ORM.Library.Infrastructure;
using EA.DAL.ORM.Library.Infrastructure.UnitOfWork; 

namespace EA.DAL.ORM.Library.Repository.EF
{
    public class EFUnitOfWork : IUnitOfWork 
    {                 
        public void Commit()
        {
            DataContextFactory.GetDataContext().SaveChanges();  
        }

        public void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            unitofWorkRepository.PersistUpdateOf(entity); 
        }

        public void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            unitofWorkRepository.PersistCreationOf(entity); 
        }

        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            unitofWorkRepository.PersistDeletionOf(entity); 
        }        
    }
}
