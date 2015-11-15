using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EA.DAL.ORM.Library.Model;
using EA.DAL.ORM.Library.Infrastructure;
using EA.DAL.QueryObject.Infrastructure.Query;
using EA.DAL.ORM.Library.Infrastructure.UnitOfWork;
using EA.DAL.ORM.Library.Repository.EF.QueryTranslators;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace EA.DAL.ORM.Library.Repository.EF.Repositories
{
    public class BookRepository : Repository<Book, Guid>, IBookRepository 
    {           
        public BookRepository(IUnitOfWork uow) : base(uow)
        {    }

        public override Book FindBy(Guid Id)
        {
            return GetObjectSet().FirstOrDefault<Book>(b => b.Id == Id);
        }

        public override IQueryable<Book> GetObjectSet()
        {
            return ((IObjectContextAdapter)DataContextFactory.GetDataContext()).ObjectContext.CreateObjectSet<Book>();
        }

        public override string GetEntitySetName()
        {
            return "Books";
        }

        public override ObjectQuery<Book> TranslateIntoObjectQueryFrom(Query query)
        {
            return new BookQueryTranslator().Translate(query); 
        }
    }
}
