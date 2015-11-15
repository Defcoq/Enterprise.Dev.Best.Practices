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
    public class BookTitleQueryTranslator : QueryTranslator 
    {
        public ObjectQuery<BookTitle> Translate(Query query)
        {
            ObjectQuery<BookTitle> bookTitleQuery;

            if (query.IsNamedQuery())
            {
                bookTitleQuery = FindEFQueryFor(query);
            }
            else
            {
                StringBuilder queryBuilder = new StringBuilder();
                IList<ObjectParameter> paraColl = new List<ObjectParameter>();
                CreateQueryAndObjectParameters(query, queryBuilder, paraColl);

                var objectContext = ((IObjectContextAdapter)DataContextFactory.GetDataContext()).ObjectContext;
                var BookTitlesSet = objectContext.CreateObjectSet<BookTitle>();
                bookTitleQuery = BookTitlesSet.Where(queryBuilder.ToString(), paraColl.ToArray()).OrderBy(String.Format("it.{0} desc", query.OrderByProperty.PropertyName));

                //bookTitleQuery = DataContextFactory.GetDataContext().BookTitles
                // .Where(queryBuilder.ToString(), paraColl.ToArray()).OrderBy(String.Format("it.{0} desc", query.OrderByProperty.PropertyName));
 
            }

            return bookTitleQuery;
        }
       
        private ObjectQuery<BookTitle> FindEFQueryFor(Query query)
        {
            // No complex queries have been defined in this sample.
            throw new NotImplementedException();
        }
    }
}
