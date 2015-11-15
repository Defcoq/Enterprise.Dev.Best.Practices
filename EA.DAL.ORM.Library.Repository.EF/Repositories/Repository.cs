using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.DAL.ORM.Library.Infrastructure;
using EA.DAL.ORM.Library.Infrastructure.UnitOfWork;
using EA.DAL.QueryObject.Infrastructure.Query;
using EA.DAL.ORM.Library.Repository.EF.QueryTranslators;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace EA.DAL.ORM.Library.Repository.EF.Repositories
{
    public abstract class Repository<T, EntityKey> : IUnitOfWorkRepository where T : IAggregateRoot
    {
        private IUnitOfWork _uow;
        private ObjectContext _objectContext = null;

        public Repository(IUnitOfWork uow)
        {
            _uow = uow;   
            _objectContext = ((IObjectContextAdapter)DataContextFactory.GetDataContext()).ObjectContext;
        }

        public void Add(T entity)
        {
            _uow.RegisterNew(entity, this);                        
        }

        public void Remove(T entity)
        {
            _uow.RegisterRemoved(entity, this);            
        }
       
        public void Save(T entity)
        {
            // Do nothing as EF tracks changes
        }

        public abstract IQueryable<T> GetObjectSet();

        public abstract string GetEntitySetName();

        public abstract T FindBy(EntityKey Id);

        public abstract ObjectQuery<T> TranslateIntoObjectQueryFrom(Query query);

        public IEnumerable<T> FindAll()
        {
            return GetObjectSet().ToList<T>(); 
        }

        public IEnumerable<T> FindAll(int index, int count)
        {
            return GetObjectSet().Skip(index).Take(count).ToList<T>(); 
        }

        public IEnumerable<T> FindBy(Query query)
        {
            ObjectQuery<T> efQuery = TranslateIntoObjectQueryFrom(query);

            return efQuery.ToList<T>();        
        }

        public IEnumerable<T> FindBy(Query query, int index, int count)
        {
            ObjectQuery<T> efQuery = TranslateIntoObjectQueryFrom(query);

            return efQuery.Skip(index).Take(count).ToList<T>();  
        }
       
        public void PersistCreationOf(IAggregateRoot entity)
        {
           
            _objectContext.AddObject(GetEntitySetName(), entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            // Do nothing as EF tracks changes
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
           _objectContext.DeleteObject(entity);
        }
    }
}
