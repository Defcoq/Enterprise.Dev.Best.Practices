using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using EA.DAL.QueryObject.Infrastructure.Query;
using EA.DAL.ORM.Library.Model;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace EA.DAL.ORM.Library.Repository.EF.QueryTranslators
{
    public class BookQueryTranslator : QueryTranslator 
    {
        public ObjectQuery<Book> Translate(Query query)
        {
            ObjectQuery<Book> bookQuery;

            if (query.IsNamedQuery())
            {
                bookQuery = FindEFQueryFor(query);
            }
            else
            {
                StringBuilder queryBuilder = new StringBuilder();
                IList<ObjectParameter> paraColl = new List<ObjectParameter>();
                CreateQueryAndObjectParameters(query, queryBuilder, paraColl);
                //cast to all EF objectContext from DbContext
                var objectContext = ((IObjectContextAdapter)DataContextFactory.GetDataContext()).ObjectContext;
                var bookSet = objectContext.CreateObjectSet<Book>();
                bookQuery = bookSet.Include("Title").OrderBy(String.Format("it.{0} desc", query.OrderByProperty.PropertyName));
            //        bookQuery = DataContextFactory.GetDataContext().Books.Include("Title").
            //      .Where(queryBuilder.ToString(), paraColl.ToArray()).OrderBy(String.Format("it.{0} desc", query.OrderByProperty.PropertyName));
            }

            return bookQuery;
        }

        private ObjectQuery<Book> FindEFQueryFor(Query query)
        {
            // No complex queries have been defined in this sample.
            throw new NotImplementedException();
        }
    }
}
