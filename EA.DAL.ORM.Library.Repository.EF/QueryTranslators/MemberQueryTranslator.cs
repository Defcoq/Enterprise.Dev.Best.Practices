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
    public class MemberQueryTranslator : QueryTranslator 
    {
        public ObjectQuery<Member> Translate(Query query)
        {
            ObjectQuery<Model.Member> memberQuery;

            if (query.IsNamedQuery())
            {
                memberQuery = FindEFQueryFor(query);
            }
            else
            {
                StringBuilder queryBuilder = new StringBuilder();
                IList<ObjectParameter> paraColl = new List<ObjectParameter>();
                CreateQueryAndObjectParameters(query, queryBuilder, paraColl);

                var objectContext = ((IObjectContextAdapter)DataContextFactory.GetDataContext()).ObjectContext;
                var memberSet = objectContext.CreateObjectSet<Member>();
                memberQuery = memberSet.Where(queryBuilder.ToString(), paraColl.ToArray()).OrderBy(String.Format("it.{0} desc", query.OrderByProperty.PropertyName));

            //    memberQuery = DataContextFactory.GetDataContext().Members
            //      .Where(queryBuilder.ToString(), paraColl.ToArray()).OrderBy(String.Format("it.{0} desc", query.OrderByProperty.PropertyName));
            }

            return memberQuery;
        }

        private ObjectQuery<Member> FindEFQueryFor(Query query)
        {
            // No complex queries have been defined in this sample.
            throw new NotImplementedException();
        }
    }
}
