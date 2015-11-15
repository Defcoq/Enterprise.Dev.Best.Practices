using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using EA.DAL.ORM.Library.Model;
using EA.DAL.ORM.Library.Infrastructure;
using EA.DAL.ORM.Library.Infrastructure.UnitOfWork;
using EA.DAL.QueryObject.Infrastructure.Query;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;

namespace EA.DAL.ORM.Library.Repository.EF.Repositories
{
    public class BookTitleRepository : Repository<BookTitle, string>, IBookTitleRepository
    {
        public BookTitleRepository(IUnitOfWork uow)
            : base(uow)
        { }

        public override BookTitle FindBy(string Id)
        {
            return GetObjectSet().FirstOrDefault<BookTitle>(b => b.ISBN == Id);
        }

        public override IQueryable<BookTitle> GetObjectSet()
        {
            return ((IObjectContextAdapter)DataContextFactory.GetDataContext()).ObjectContext.CreateObjectSet<BookTitle>();
        }

        public override string GetEntitySetName()
        {
            return "BookTitles";
        }

        public override ObjectQuery<BookTitle> TranslateIntoObjectQueryFrom(Query query)
        {
            throw new NotImplementedException();
        }
    }    
}
